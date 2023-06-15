using DrivingSchoolSystem.Core.Constants;
using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.StudentCard;
using DrivingSchoolSystem.Extensions;
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
            this.studentCardService = _studentCardService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await studentCardService.GetAll(User.Id(), User.Role());

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstant.Instructor)]
        public async Task<IActionResult> Add()
        {
            var model = await studentCardService.GetAddModelAsync(User.Id());

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstant.Instructor)]
        public async Task<IActionResult> Add(StudentCardAddServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await studentCardService.AddAsync(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Грешка при запазването на данните!");

                return View(model);
            }


            return RedirectToAction("All");
        }

        public IActionResult Index()
        {
            return RedirectToAction("All");
        }
    }
}
