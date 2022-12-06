﻿using Microsoft.AspNetCore.Mvc;

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
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}