using DrivingSchoolSystem.Core.Constants;
using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Services;
using DrivingSchoolSystem.Extensions;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (!User.IsInRole(RoleConstant.Admin))
            {
                ViewBag.DrivingSchoolName = Request.Cookies["userDrivingSchoolName"];
            }
            ViewBag.UserFullName = Request.Cookies["userFullName"];
            ViewBag.Role = User.BulgarianRoleName();

            return View();
        }
    }
}
