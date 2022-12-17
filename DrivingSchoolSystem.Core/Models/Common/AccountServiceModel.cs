using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Common
{
    public abstract class AccountServiceModel
    {
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
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Имейл: ")]
        public string Email { get; set; } = null!;

        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон: ")]
        public string PhoneNumber { get; set; } = null!;
    }
}
