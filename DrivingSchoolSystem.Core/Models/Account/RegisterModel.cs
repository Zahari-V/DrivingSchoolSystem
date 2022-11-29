using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Account
{
    public class RegisterModel
    {
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

        public bool IsDisplay { get; set; }
    }
}
