using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.StudentCard;
using DrivingSchoolSystem.Extensions;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Controllers
{
    [Authorize]
    public class StudentCardController : Controller
    {
        private IStudentCardService studentCardService;

        public StudentCardController(IStudentCardService _studentCardService)
        {
            studentCardService = _studentCardService;
        }

        public IActionResult All()
        {
            var model = studentCardService.GetAll(User.Id());

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Add()
        {
            var model = new AddStudentCardModel()
            {
                Students = studentCardService.GetStudents(User.DrivingSchoolId()),
                Courses = studentCardService.GetCourses(User.DrivingSchoolId()),
                InstructorId = await studentCardService.GetInstructorId(User.Id())
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Add(AddStudentCardModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Students = studentCardService.GetStudents(User.DrivingSchoolId());
                model.Courses = studentCardService.GetCourses(User.DrivingSchoolId());

                return View(model);
            }

            try
            {
                await studentCardService.AddStudentCardAsync(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }


            return RedirectToAction("All");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
