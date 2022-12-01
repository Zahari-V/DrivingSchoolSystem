using Microsoft.AspNetCore.Identity;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class Role : IdentityRole
    {
        public IEnumerable<UserRole> UsersRoles { get; set; } = new List<UserRole>();
    }
}
