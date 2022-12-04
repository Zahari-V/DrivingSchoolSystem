using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace DrivingSchoolSystem.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IDrivingSchoolService drivingSchoolService;

        public AccountController(
            SignInManager<User> _signInManager, 
            UserManager<User> _userManager,
            IDrivingSchoolService _drivingSchoolService)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            drivingSchoolService = _drivingSchoolService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("System", "Home");
            }

            return View(new LoginModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.Username);

            if (user != null)
            {
                var result = await signInManager
                .PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {

                    CookieOptions option = new CookieOptions()
                    {
                        HttpOnly = true
                    };

                    Response.Cookies
                        .Append("userFullName", $"{user.FirstName} {user.MiddleName} {user.LastName}", option);

                    Response.Cookies
                        .Append("userDrivingSchoolName"
                        , await drivingSchoolService.GetNameByIdAsync(user.DrivingSchoolId), option);

                    return RedirectToAction("System", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid Login!");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            Response.Cookies.Delete("userFullName");
            Response.Cookies.Delete("userDrivingSchoolName");

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ProvidedEmail()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("System", "Home");
            }

            var model = new ProvidedEmailModel()
            {
                DrivingSchools = await drivingSchoolService.GetAll()
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ProvidedEmail(ProvidedEmailModel model)
        {
            model.DrivingSchools = await drivingSchoolService.GetAll();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Грешка в модела!");

                return View(model);
            }

            var emailExistInDrivingSchool = await userManager.Users
                .AnyAsync(u => u.DrivingSchoolId == model.DrivingSchoolId && u.Email == model.Email);

            if (emailExistInDrivingSchool)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user.IsRegistered)
                {
                    return RedirectToAction("Login");
                }

                return RedirectToAction
                    ("RegisterConfirmation", "Account", 
                    new { email = model.Email, userId = user.Id});
            }

            ModelState.AddModelError("", "Няма такъв имейл в тази автошкола!");

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> RegisterConfirmation(string email, string userId)
        {
            if (email == null || userId == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound($"Не може да се намери потребител с този имейл '{email}'.");
            }

            if (user.IsRegistered)
            {
                return RedirectToAction("Login");
            }

            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            ViewBag.EmailConfirmationUrl = Url.Action("Register", "Account", new { userId = userId, code = code });

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            if (user.IsRegistered)
            {
                return RedirectToAction("Login");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                var res = await userManager.UpdateAsync(user);

                if (!res.Succeeded)
                {
                    throw new ArgumentException("Email not confirmed!!!");
                }
            }
          
            var model = new RegisterModel();

            model.Email = user.Email;
            model.DrivingSchoolName = await drivingSchoolService
                .GetNameByIdAsync(user.DrivingSchoolId);
            model.IsDisplay = user.EmailConfirmed;  

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return NotFound($"Не може да се намери потребител с този имейл '{model.Email}'.");
            }

            user.UserName = model.Username;
            user.NormalizedUserName = model.Username.ToUpper();

            var hasher = new PasswordHasher<User>();
            user.PasswordHash =
                 hasher.HashPassword(user, model.Password);
            user.IsRegistered = true;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Грешка при запазването на данните.");

                return View(model);
            }

            var claim = new Claim("DrivingSchoolId", $"{user.DrivingSchoolId}");
            var claimRes = await userManager.AddClaimAsync(user, claim);

            if (!claimRes.Succeeded)
            {
                ModelState.AddModelError("", "Грешка при запазването на данните.");

                return View(model);
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
