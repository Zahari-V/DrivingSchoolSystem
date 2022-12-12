using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.User
{
    public class RegisterModel
    {
        public Guid AccountId { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string MiddleName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        public string DrivingSchoolName { get; set; } = null!;
    }
}
