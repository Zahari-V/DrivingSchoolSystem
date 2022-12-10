using DrivingSchoolSystem.Infrastructure.Data.Models;
using System.Security.Claims;

namespace DrivingSchoolSystem.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static int DrivingSchoolId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirstValue("DrivingSchoolId"));
        }

        public static string Role(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Role);
        }

        public static string BulgarianRoleName(this ClaimsPrincipal user)
        {
            var roleName = user.Role().ToUpper();

            if (roleName == "STUDENT")
            {
                roleName = "Ученик";
            }
            else if (roleName == "INSTRUCTOR")
            {
                roleName = "Инструктор";
            }
            else
            {
                roleName = "Администратор";
            }

            return roleName;
        }
    }
}
