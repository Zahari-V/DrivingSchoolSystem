using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DrivingSchoolSystem.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            int userDrivingSchoolId = int.Parse(User.DrivingSchoolId());

            var model = await accountService.GetAllByDrivingSchoolIdAsync(userDrivingSchoolId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddModel()
            {
                DrivingSchoolId = int.Parse(User.DrivingSchoolId()),
                Roles = await accountService.GetRolesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Roles = await accountService.GetRolesAsync();

                return View(model);
            }

            try
            {
                await accountService.AddAccountAsync(model);

                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"{ex.Message}");

                return View(model);
            }
        }
    }
}
