using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Course;
using DrivingSchoolSystem.Extensions;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Areas.Admin.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourseService courseService;
        private readonly IDrivingSchoolService drivingSchoolService;

        public CourseController(
            ICourseService _courseService,
            IDrivingSchoolService _drivingSchoolService)
        {
            courseService = _courseService;
            drivingSchoolService = _drivingSchoolService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var drivingSchoolId = int.Parse(User.DrivingSchoolId());

            var model = courseService.GetAllCourses(drivingSchoolId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var drivingSchoolId = int.Parse(User.DrivingSchoolId());

            var model = new AddCourseModel()
            {
                AdminId = User.Id(),
                Categories = await drivingSchoolService.GetDrivingSchoolCategories(drivingSchoolId)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCourseModel model)
        {
            if (!ModelState.IsValid)
            {
                var drivingSchoolId = int.Parse(User.DrivingSchoolId());

                model.Categories = await drivingSchoolService.GetDrivingSchoolCategories(drivingSchoolId);

                return View(model);
            }

            try
            {
                await courseService.AddCourseAsync(model);

                return RedirectToAction("All");
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
