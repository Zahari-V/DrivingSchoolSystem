using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
                return RedirectToAction("System");
            }

            return View();
        }

        public IActionResult System()
        {
            return View();
        }
    }
}