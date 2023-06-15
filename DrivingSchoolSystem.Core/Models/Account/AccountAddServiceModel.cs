using DrivingSchoolSystem.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Account
{
    public class AccountAddServiceModel : AccountServiceModel
    {
        [Required]
        public int DrivingSchoolId { get; set; }

        [Display(Name = "Длъжност: ")]
        public string RoleId { get; set; } = null!;

        public IEnumerable<RoleModel> Roles { get; set; } = new List<RoleModel>();

        [Display(Name = "Обучаващи категории на инструктора: ")]
        public List<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
