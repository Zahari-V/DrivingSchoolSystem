using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Areas.Admin.Controllers
{
    public class CourseController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
