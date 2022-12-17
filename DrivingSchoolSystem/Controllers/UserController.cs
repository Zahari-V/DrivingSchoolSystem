using DrivingSchoolSystem.Core.Constants;
using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.User;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using System.Text;

namespace DrivingSchoolSystem.Controllers
{
    /// <summary>
    /// Controller for the logic of Registration and Authentication 
    /// </summary>
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

            User user = null;

            try
            {
                user = await userService.GetUserByUsernameAsync(model.Username);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Невалидни данни!");

                return View(model);
            }

            var result = await signInManager
                .PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                CookieOptions option = new CookieOptions()
                {
                    HttpOnly = true
                };

                //Appending cookie "userFullName" needed for some views.
                Response.Cookies
                    .Append("userFullName", $"{user.Account?.FirstName} {user.Account?.MiddleName} {user.Account?.LastName}", option);

                //Appending cookie "userDrivingSchoolName" needed for some views.
                if (!await userManager.IsInRoleAsync(user, "Admin"))
                {
                    Response.Cookies
                        .Append("userDrivingSchoolName", user.Account.DrivingSchool.Name);
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Невалидни данни!");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            //Deleting unnecessary cookies.
            Response.Cookies.Delete("userFullName");
            
            if (!User.IsInRole(RoleConstant.Admin))
            {
                Response.Cookies.Delete("userDrivingSchoolName");
            }

            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        //This action is provided to user.
        //He must input email which he provided to driving school and selected right driving school.
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

        //This action is responding about whether user has account in driving school.
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

            var account = await userService.GetByProvidedEmailAsync(model.Email, model.DrivingSchoolId);

            if (account != null)
            {

                if (account.UserId != null)
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

        //This action is provided to user.
        //He must input right personal data for authentication.
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register(string accountId)
        {
            if (accountId == null)
            {
                return RedirectToPage("/Index");
            }

            //Account who is created for specified person
            var account = await userService.GetByIdAsync(Guid.Parse(accountId));

            if (account == null)
            {
                return NotFound();
            }

            if (account.UserId != null)
            {
                return RedirectToAction("Login");
            }

            var model = new RegisterModel();
            
            model.Email = account.Email;
            model.DrivingSchoolName = account.DrivingSchool.Name;
            model.AccountId = account.Id;

            return View(model);
        }

        //This action is responding about whether user data are same as account data.
        //If data are same user is registered successful.
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Get account by id with tracking
            var account = await userService.GetByIdAsync(model.AccountId);

            if (account == null)
            {
                return NotFound($"Не може да се намери акаунт с този това ID '{model.AccountId}'.");
            }

            // Checking if the data matches
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
                Account = account // Relating user with provided account
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Adding claim "DrivingSchoolId" to user.
                // It is is used to access only the own driving school.
                var claim = new Claim("DrivingSchoolId", $"{account.DrivingSchoolId}");
                var claimResult = await userManager.AddClaimAsync(user, claim);

                // Adding user to role which is specified from account.
                var roleResult = await userManager.AddToRoleAsync(user, account.Role.Name);

                if (!claimResult.Succeeded || !roleResult.Succeeded)
                {
                    ModelState.AddModelError("", "Грешка при запазването на данните.");

                    return View(model);
                }

                return RedirectToAction("RegisterConfirmation", new { userId = user.Id});
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        //This action displaying demonstration for register confirmation.
        [AllowAnonymous]
        [HttpGet]
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

        //This action displaying demonstration for confirmed email.
        [AllowAnonymous]
        [HttpGet]
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
