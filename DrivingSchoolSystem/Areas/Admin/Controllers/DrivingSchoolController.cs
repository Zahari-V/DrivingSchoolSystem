using DrivingSchoolSystem.Core.Contracts.Admin;
using DrivingSchoolSystem.Core.Models.Admin.DrivingSchool;
using DrivingSchoolSystem.Core.Services.Admin;
using DrivingSchoolSystem.Extensions;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DrivingSchoolSystem.Areas.Admin.Controllers
{
    public class DrivingSchoolController : BaseController
    {
        private readonly IDrivingSchoolService drivingSchoolService;

        public DrivingSchoolController(IDrivingSchoolService _drivingSchoolService)
        {
            drivingSchoolService = _drivingSchoolService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            var model = drivingSchoolService.GetAll();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            var model = new AddDrivingSchoolModel();

            model.DrivingSchool.EducationCategories = await drivingSchoolService.GetCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddDrivingSchoolModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await drivingSchoolService.AddAsync(model);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при запазването на данните!");

                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            if (User.IsInRole("Manager") && id != User.DrivingSchoolId())
            {
                return Redirect("/Error/AccessDenied");
            }

            var model = await drivingSchoolService.GetByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (User.IsInRole("Manager") && id != User.DrivingSchoolId())
            {
                return Redirect("/Error/AccessDenied");
            }

            var model = await drivingSchoolService.GetByIdAsync(id);

            model.EducationCategories = await drivingSchoolService
                .MarkCategoriesAsync(model.EducationCategories);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(DrivingSchoolModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (User.IsInRole("Manager") && model.Id != User.DrivingSchoolId())
            {
                return Redirect("/Error/AccessDenied");
            }

            try
            {
                await drivingSchoolService.EditAsync(model);

                return RedirectToAction("Info", new { id = model.Id});

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await drivingSchoolService.DeleteAsync(id);

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
