using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.DrivingSchool;
using DrivingSchoolSystem.Extensions;
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
        public async Task<IActionResult> EditProfile(DrivingSchoolInfoModel model)
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
