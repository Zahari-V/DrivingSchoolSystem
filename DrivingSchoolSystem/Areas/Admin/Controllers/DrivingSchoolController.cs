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
            var drivingSchoolId = int.Parse(User.DrivingSchoolId());

            var model = await drivingSchoolService.GetDrivingSchoolInfoByIdAsync(drivingSchoolId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var drivingSchoolId = int.Parse(User.DrivingSchoolId());

            var model = await drivingSchoolService.GetDrivingSchoolInfoByIdAsync(drivingSchoolId);

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
                await drivingSchoolService.EditProfileAsync(model);

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
