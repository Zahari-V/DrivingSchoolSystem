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

        public CourseController(ICourseService _courseService)
        {
            courseService = _courseService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = courseService.GetAllCourses(User.DrivingSchoolId());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddCourseModel()
            {
                AdminId = User.Id(),
                Categories = await courseService.GetCourseCategoriesAsync(User.DrivingSchoolId())
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCourseModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await courseService.GetCourseCategoriesAsync(User.DrivingSchoolId());

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
