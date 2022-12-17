using DrivingSchoolSystem.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Admin.Account
{
    public class AccountEditServiceModel : AccountServiceModel
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Длъжност: ")]
        public string RoleName { get; set; } = null!;

        [Display(Name = "Категории на инструктора: ")]
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
