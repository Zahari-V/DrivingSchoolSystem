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
            var model = accountService.GetAllByDrivingSchoolId(User.DrivingSchoolId());

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
                await accountService.AddAsync(model);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при запазването на данните.");

                model.Roles = await accountService.GetRolesAsync();

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Info(Guid id)
        {
            try
            {
                var model = await accountService.GetInfoByIdAsync(id, User.Role());

                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var model = await accountService.GetEditModelByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(AccountEditServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await accountService.EditAsync(model);

                return RedirectToAction("Info", new { id = model.Id });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await accountService.Delete(id);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
