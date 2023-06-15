using DrivingSchoolSystem.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.DrivingSchool
{
    public class DrivingSchoolModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Име на автошколата: ")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(25)]
        [Display(Name = "Град: ")]
        public string Town { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Display(Name = "Адрес: ")]
        public string Address { get; set; } = null!;

        [StringLength(15)]
        [Display(Name = "Телефон: ")]
        public string? PhoneContact { get; set; }

        [Display(Name = "Обучаващи категории: ")]
        public List<CategoryModel> EducationCategories { get; set; } = new List<CategoryModel>();
    }
}
