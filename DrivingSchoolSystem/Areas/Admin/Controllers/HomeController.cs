using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Services;
using DrivingSchoolSystem.Extensions;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IDrivingSchoolService drivingSchoolService;

        public HomeController(
            UserManager<User> _userManager,
            IDrivingSchoolService _drivingSchoolService)
        {
            userManager = _userManager;
            drivingSchoolService = _drivingSchoolService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByIdAsync(User.Id());

            ViewBag.DrivingSchoolName = await drivingSchoolService
                .GetDrivingSchoolNameAsync(user.DrivingSchoolId);
            ViewBag.UserFullName = $"{user.FirstName} {user.MiddleName} {user.LastName}";
            
            return View();
        }
    }
}
