using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Account
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
