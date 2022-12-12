using DrivingSchoolSystem.Core.Contracts.Admin;
using DrivingSchoolSystem.Core.Models.Admin.Account;
using DrivingSchoolSystem.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        public IActionResult All()
        {
            var model = accountService.GetAllByDrivingSchoolId(User.DrivingSchoolId(), User.Role());

            return View(model);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddAccountModel()
            {
                DrivingSchoolId = User.DrivingSchoolId(),
                Roles = await accountService.GetRolesAsync(),
                Categories = await accountService.GetCategoriesAsync()
            };

            return View(model);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Add(AddAccountModel model)
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

                model.Roles = await accountService.GetRolesAsync();

                return View(model);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public IActionResult Edit(string accountId)
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
