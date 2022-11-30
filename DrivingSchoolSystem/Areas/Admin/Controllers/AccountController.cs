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
            //int userDrivingSchoolId = int.Parse(User.DrivingSchoolId());

            //var model = await accountService.GetAllByDrivingSchoolIdAsync(userDrivingSchoolId);

            //foreach (var account in model)
            //{
            //    account.RoleName = await accountService.GetRoleNameByUserIdAsync(account.Id);
            //}

            return View();
        }

        public async Task<IActionResult> All()
        {
            int userDrivingSchoolId = int.Parse(User.DrivingSchoolId());

            var model = await accountService.GetAllByDrivingSchoolIdAsync(userDrivingSchoolId);

            foreach (var account in model)
            {
                account.RoleName = await accountService.GetRoleNameByUserIdAsync(account.Id);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddModel()
            {
                DrivingSchoolId = int.Parse(User.DrivingSchoolId()),
                Roles = accountService.GetRoles()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AddModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Roles = accountService.GetRoles();

                return View(model);
            }

            return RedirectToAction("All");
        }
    }
}
