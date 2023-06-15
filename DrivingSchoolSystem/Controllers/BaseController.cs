using DrivingSchoolSystem.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrivingSchoolSystem.Controllers
{
    [Route("[controller]/[Action]/{id?}")]
    [Authorize(Roles = $"{RoleConstant.Admin}, {RoleConstant.Manager}")]
    public class BaseController : Controller
    {
    }
}
