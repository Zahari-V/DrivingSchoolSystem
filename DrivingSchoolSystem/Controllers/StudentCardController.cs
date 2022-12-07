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
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Instructor")]
        public IActionResult Add()
        {
            var model = new AddStudentCardModel()
            {
                Accounts = studentCardService.GetAccounts(User.DrivingSchoolId()),
                Courses = studentCardService.GetCourses(User.DrivingSchoolId())
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> Add(AddStudentCardModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Accounts = studentCardService.GetAccounts(User.DrivingSchoolId());
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


            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
