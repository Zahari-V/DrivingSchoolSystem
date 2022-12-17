using DrivingSchoolSystem.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = $"{RoleConstant.Admin}, {RoleConstant.Manager}")]
    public class BaseController : Controller
    {
    }
}
