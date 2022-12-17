using DrivingSchoolSystem.Core.Constants;
using DrivingSchoolSystem.Core.Contracts.Admin;
using DrivingSchoolSystem.Core.Models.Admin.DrivingSchool;
using DrivingSchoolSystem.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Authorize(Roles = RoleConstant.Admin)]
        public IActionResult All()
        {
            var model = drivingSchoolService.GetAll();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstant.Admin)]
        public async Task<IActionResult> Add()
        {
            var model = new DrivingSchoolAddServiceModel();

            model.DrivingSchool.EducationCategories = await drivingSchoolService.GetCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstant.Admin)]
        public async Task<IActionResult> Add(DrivingSchoolAddServiceModel model)
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
            if (User.IsInRole(RoleConstant.Manager) && id != User.DrivingSchoolId())
            {
                return Redirect("/Error/AccessDenied");
            }

            try
            {
                var model = await drivingSchoolService.GetByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (User.IsInRole(RoleConstant.Manager) && id != User.DrivingSchoolId())
            {
                return Redirect("/Error/AccessDenied");
            }

            try
            {
                var model = await drivingSchoolService.GetByIdAsync(id);

                model.EducationCategories = await drivingSchoolService
                .MarkCategoriesAsync(model.EducationCategories);

                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DrivingSchoolModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            try
            {
                await drivingSchoolService.EditAsync(model);

                return RedirectToAction("Info", new { id = model.Id });
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при запазването на данните.");

                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = RoleConstant.Admin)]
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
            return RedirectToAction("All");
        }
    }
}
