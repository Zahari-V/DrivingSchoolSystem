using System.ComponentModel.DataAnnotations;
using DrivingSchoolSystem.Core.Models.Common;

namespace DrivingSchoolSystem.Core.Models.Admin.Account
{
    public class AccountInfoViewModel : AccountServiceModel
    {
        [Required]
        public Guid Id { get; set; }

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
