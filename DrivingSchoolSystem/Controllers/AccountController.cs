using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        private IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("System", "Home");
            }

            return View(new RegisterViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        private async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (true)
            {

            }

            User user = new User()
            {
                UserName = model.Username,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("System", "Home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("System", "Home");
            }

            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
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
                    return RedirectToAction("System", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid Login!");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ProvidedEmail()
        {
            var model = new ProvidedEmailModel()
            {
                DrivingSchools = drivingSchoolService.GetAllDrivingSchools()
            };

            return View(model);
        }
    }
}
