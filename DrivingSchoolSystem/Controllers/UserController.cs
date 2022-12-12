using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.User;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace DrivingSchoolSystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public UserController(
            SignInManager<User> _signInManager, 
            UserManager<User> _userManager,
            IUserService _userService)
        {
            signInManager = _signInManager;
            userManager = _userManager;
            userService = _userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
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

            var user = await userManager.Users
                .AsNoTracking()
                .Include(u => u.Account)
                .ThenInclude(a => a.DrivingSchool)
                .FirstOrDefaultAsync(u => u.NormalizedUserName == model.Username.ToUpper());

            if (user != null)
            {
                var result = await signInManager
                .PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (!await userManager.IsInRoleAsync(user, "Admin"))
                    {
                        CookieOptions option = new CookieOptions()
                        {
                            HttpOnly = true
                        };

                        Response.Cookies
                            .Append("userFullName", $"{user.Account.FirstName} {user.Account.MiddleName} {user.Account.LastName}", option);

                        Response.Cookies
                            .Append("userDrivingSchoolName", user.Account.DrivingSchool.Name);
                    }

                    return RedirectToAction("Index", "Home");
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
        public IActionResult ProvidedEmail()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new ProvidedEmailModel()
            {
                DrivingSchools = userService.GetDrivingSchools()
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ProvidedEmail(ProvidedEmailModel model)
        {
            if (!ModelState.IsValid)
            {
                model.DrivingSchools = userService.GetDrivingSchools();

                ModelState.AddModelError("", "Грешка в модела!");

                return View(model);
            }

            var account = await userService.GetAsync(model.DrivingSchoolId, model.Email);

            if (account != null)
            {

                if (account.IsRegistered)
                {
                    return RedirectToAction("Login");
                }

                return RedirectToAction
                    ("Register", "User",
                    new { accountId = account.Id.ToString() });
                
            }

            ModelState.AddModelError("", "Грешка при намирането на акаунта!");

            model.DrivingSchools = userService.GetDrivingSchools();

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register(string accountId)
        {
            if (accountId == null)
            {
                return RedirectToPage("/Index");
            }

            var account = await userService.GetByIdAsync(Guid.Parse(accountId));

            if (account == null)
            {
                return NotFound($"Не може да се намери акаунт с ID '{accountId}'.");
            }

            if (account.IsRegistered)
            {
                return RedirectToAction("Login");
            }

            var model = new RegisterModel();
            
            model.Email = account.Email;
            model.DrivingSchoolName = account.DrivingSchool.Name;
            model.AccountId = account.Id;

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

            var account = await userService.GetByIdAsync(model.AccountId);

            if (account == null)
            {
                return NotFound($"Не може да се намери акаунт с този това ID '{model.AccountId}'.");
            }

            if (!await userService.IsValidData(model))
            {
                ModelState.AddModelError("", "Няма акаунт с тези лични данни! Моля въведете правилни лични данни!");

                return View(model);
            }

            var user = new User()
            {
                Email = account.Email,
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber,
                Account = account
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var claim = new Claim("DrivingSchoolId", $"{account.DrivingSchoolId}");
                var claimResult = await userManager.AddClaimAsync(user, claim);

                var roleResult = await userManager.AddToRoleAsync(user, account.Role.Name);

                if (!claimResult.Succeeded || !roleResult.Succeeded)
                {
                    ModelState.AddModelError("", "Грешка при запазването на данните.");

                    return View(model);
                }

                await userService.RegisterAccount(account.Id);

                return RedirectToAction("RegisterConfirmation", new { userId = user.Id});
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);

            
        }

        [AllowAnonymous]
        public async Task<IActionResult> RegisterConfirmation(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("Потребителя не е намерен!!!");
            }

            var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            ViewBag.EmailConfirmationUrl = Url.Action("EmailConfirmed", "User"
                , new { userId = userId, code = code });

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> EmailConfirmed(string userId, string code)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("Потребителя не е намерен!!!");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await userManager.ConfirmEmailAsync(user, code);

            ViewBag.Succeeded = result.Succeeded;
            ViewBag.StatusMessage = result.Succeeded ? "Благодаря за потвържаването на имейла." : "Грешка при потвържаването на имейла.";

            return View();
        }
    }
}
