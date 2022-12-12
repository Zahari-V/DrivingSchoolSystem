using DrivingSchoolSystem.Core.Contracts.Admin;
using DrivingSchoolSystem.Core.Models.Admin.Course;
using DrivingSchoolSystem.Extensions;
using Microsoft.AspNetCore.Authorization;
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
            var model = courseService.GetAllCourses(User.DrivingSchoolId(), User.Role());

            return View(model);
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddCourseModel()
            {
                ManagerId = await courseService.GetManagerIdAsync(User.Id()),
                Categories = await courseService.GetEducationCategoriesAsync(User.DrivingSchoolId())
            };

            return View(model);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Add(AddCourseModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await courseService.GetEducationCategoriesAsync(User.DrivingSchoolId());

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

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> Edit(int courseId)
        {
            var model = await courseService.GetEditModelByIdAsync(courseId);
            model.Categories = await courseService.GetEducationCategoriesAsync(User.DrivingSchoolId());
            model.ManagerId = await courseService.GetManagerIdAsync(User.Id());

            return View(model);
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditCourseModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await courseService.GetEducationCategoriesAsync(User.DrivingSchoolId());

                return View(model);
            }

            try
            {
                await courseService.EditAsync(model);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при запазването на данните!");

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int courseId)
        {
            try
            {
                await courseService.DeleteCourseAsync(courseId);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                return NotFound("Нещо се обърка!!!");
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
