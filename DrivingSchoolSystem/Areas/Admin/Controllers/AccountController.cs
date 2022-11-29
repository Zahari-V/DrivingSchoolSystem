using DrivingSchoolSystem.Core.Contracts;
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

        public IActionResult Index()
        {
            var model = accountService.GetAll();

            return View(model);
        }
    }
}
