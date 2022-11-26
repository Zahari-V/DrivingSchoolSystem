using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30)]
        public string MiddleName { get; set; } = null!;

        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = null!;

        [StringLength(400)]
        public string? ImageUrl { get; set; }

        [Required]
        public bool IsRegistered { get; set; }

        [Required]
        public int DrivingSchoolId { get; set; }

        [ForeignKey(nameof(DrivingSchoolId))]
        public DrivingSchool DrivingSchool { get; set; } = null!;
    }
}
