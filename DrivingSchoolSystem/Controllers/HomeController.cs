using DrivingSchoolSystem.Extensions;
using DrivingSchoolSystem.Models;
using Microsoft.AspNetCore.Mvc;

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
                if (!User.IsInRole("Admin"))
                {
                    ViewBag.DrivingSchoolName = Request.Cookies["userDrivingSchoolName"];
                    ViewBag.UserFullName = Request.Cookies["userFullName"];
                    ViewBag.Role = User.BulgarianRoleName();
                }

                return View("HomePage");
            }

            return View();
        }

        public IActionResult About() => View();

        [Route("/AccessDenied")]
        public IActionResult AccessDenied() => View();

        [Route("Error/404")]
        public IActionResult Error404(string message = "Не е намерено")
        {
            ViewBag.Message = message;
            return View("Error404");
        }

        [Route("error/{code:int}")]
        public IActionResult Error(int code)
        {
            // handle different codes or just return the default error view
            return View(new ErrorViewModel());
        }
    }
}