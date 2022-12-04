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
    }
}
