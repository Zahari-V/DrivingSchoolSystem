using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Admin.Account
{
    public class AccountInfoViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Собствено име: ")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30)]
        [Display(Name = "Бащино име: ")]
        public string MiddleName { get; set; } = null!;

        [Required]
        [StringLength(30)]
        [Display(Name = "Фамилно име: ")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(25)]
        [Display(Name = "Имейл: ")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(12)]
        [Display(Name = "Телефон: ")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Display(Name = "Длъжност: ")]
        public string RoleName { get; set; } = null!;

        [Required]
        [Display(Name = "Регистриран: ")]
        public string Registered { get; set; } = null!;

        [Display(Name = "Автошкола: ")]
        public string? DrivingSchoolName { get; set; }
    }
}
