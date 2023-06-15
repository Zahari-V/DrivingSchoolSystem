using DrivingSchoolSystem.Core.Constants;
using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Course;
using DrivingSchoolSystem.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Controllers
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
            var model = courseService.GetAll(User.DrivingSchoolId(), User.Role());

            return View(model);
        }

        [Authorize(Roles = RoleConstant.Manager)]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CourseServiceModel()
            {
                ManagerId = await courseService.GetManagerIdAsync(User.Id()),
                Categories = await courseService.GetEducationCategoriesAsync(User.DrivingSchoolId())
            };

            return View(model);
        }

        [Authorize(Roles = RoleConstant.Manager)]
        [HttpPost]
        public async Task<IActionResult> Add(CourseServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await courseService.GetEducationCategoriesAsync(User.DrivingSchoolId());

                return View(model);
            }

            try
            {
                await courseService.AddAsync(model);

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при запазването на данните!");

                return View(model);
            }
        }

        [Authorize(Roles = RoleConstant.Manager)]
        [HttpGet]
        public async Task<IActionResult> Edit(int courseId)
        {
            try
            {
                var model = await courseService.GetByIdAsync(courseId);
                model.Categories = await courseService.GetEducationCategoriesAsync(User.DrivingSchoolId());
                model.ManagerId = await courseService.GetManagerIdAsync(User.Id());

                return View(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = RoleConstant.Manager)]
        [HttpPost]
        public async Task<IActionResult> Edit(CourseServiceModel model)
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
                return NotFound();
            }
        }

        public IActionResult Index()
        {
            return RedirectToAction("All");
        }
    }
}
