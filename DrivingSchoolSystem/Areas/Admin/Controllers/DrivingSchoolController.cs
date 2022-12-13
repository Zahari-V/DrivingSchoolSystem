using DrivingSchoolSystem.Core.Contracts.Admin;
using DrivingSchoolSystem.Core.Models.Admin.DrivingSchool;
using DrivingSchoolSystem.Extensions;
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
        public async Task<IActionResult> Profile()
        {
            var model = await drivingSchoolService.GetInfoByIdAsync(User.DrivingSchoolId());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var model = await drivingSchoolService.GetInfoByIdAsync(User.DrivingSchoolId());

            model.EducationCategories = await drivingSchoolService.MarkDrivingSchoolCategoriesAsync(model.EducationCategories);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(DrivingSchoolModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await drivingSchoolService.EditInfoAsync(model);

                return RedirectToAction("Profile");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
