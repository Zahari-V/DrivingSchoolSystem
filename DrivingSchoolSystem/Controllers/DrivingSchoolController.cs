using DrivingSchoolSystem.Core.Constants;
using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.DrivingSchool;
using DrivingSchoolSystem.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Controllers
{
    public class DrivingSchoolController : BaseController
    {
        private readonly IDrivingSchoolService drivingSchoolService;

        public DrivingSchoolController(IDrivingSchoolService _drivingSchoolService)
        {
            drivingSchoolService = _drivingSchoolService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await drivingSchoolService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstant.Admin)]
        public async Task<IActionResult> Add()
        {
            var model = new DrivingSchoolServiceModel();

           // model.DrivingSchool.EducationCategories = await drivingSchoolService.GetCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstant.Admin)]
        public async Task<IActionResult> Add(DrivingSchoolServiceModel model)
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
                var model = await drivingSchoolService.GetInfoByIdAsync(id, User.Role());

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
                var model = await drivingSchoolService.GetInfoByIdAsync(id, User.Role());

                //model.DrivingSchool.EducationCategories = await drivingSchoolService
                //.MarkCategoriesAsync(model.DrivingSchool.EducationCategories);

                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DrivingSchoolServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            try
            {
                await drivingSchoolService.EditAsync(model, User.Role());

                return RedirectToAction("Info", new { id = model.DrivingSchool.Id });
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
