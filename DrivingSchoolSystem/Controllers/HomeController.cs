using DrivingSchoolSystem.Core.Constants;
using DrivingSchoolSystem.Extensions;
using DrivingSchoolSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;

namespace DrivingSchoolSystem.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        { }

        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                Response.Cookies.Append("IsAuthenticated", "true");

                if (!User.IsInRole(RoleConstant.Admin))
                {
                    ViewBag.DrivingSchoolName = Request.Cookies["userDrivingSchoolName"];
                }
                ViewBag.UserFullName = Request.Cookies["userFullName"];
                ViewBag.Role = User.BulgarianRoleName();

                return View("HomePage");
            }

            return View();
        }

        public IActionResult About() => View();

        [Route("Error/AccessDenied")]
        public IActionResult AccessDenied() => View();

        [Route("Error/{code:int}")]
        public IActionResult Error(int? code = null)
        {
            if (code.HasValue)
            {
                if (code == StatusCodes.Status404NotFound)
                {
                    return View("Error404");
                }
            }
            
            return View(new ErrorViewModel());
        }
    }
}