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
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Instructor")]
        public IActionResult Add()
        {
            var model = new AddStudentCardModel()
            {
                Accounts = studentCardService.GetAccountsAsync(User.DrivingSchoolId()),
                Courses = studentCardService.GetCoursesAsync(User.DrivingSchoolId())
            };

            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
