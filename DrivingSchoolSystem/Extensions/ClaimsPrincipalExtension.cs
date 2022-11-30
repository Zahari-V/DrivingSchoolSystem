using System.Security.Claims;

namespace DrivingSchoolSystem.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static string DrivingSchoolId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue("DrivingSchoolId");
        }
    }
}
