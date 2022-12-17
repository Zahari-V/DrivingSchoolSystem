using DrivingSchoolSystem.Infrastructure.Data.DataConstants;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class Account
    {
        public Account()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(AccountConstant.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(AccountConstant.MiddleNameMaxLength)]
        public string MiddleName { get; set; } = null!;

        [Required]
        [StringLength(AccountConstant.LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(AccountConstant.EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(AccountConstant.EmailMaxLength)]
        public string NormalizedEmail { get; set; } = null!;

        [Required]
        [StringLength(AccountConstant.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string RoleId { get; set; } = null!;

        [ForeignKey(nameof(RoleId))]
        public IdentityRole Role { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; }

        public int? DrivingSchoolId { get; set; }

        [ForeignKey(nameof(DrivingSchoolId))]
        public DrivingSchool? DrivingSchool { get; set; }

        public string? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
