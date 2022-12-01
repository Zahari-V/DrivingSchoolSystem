using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class UserRole : IdentityUserRole<string>
    {
        public User User { get; set; } = null!;

        public Role Role { get; set; } = null!;
    }
}
