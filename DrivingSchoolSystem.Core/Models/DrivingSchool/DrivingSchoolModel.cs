using DrivingSchoolSystem.Core.Models.Common;
using DrivingSchoolSystem.Infrastructure.Data.DataConstants;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.DrivingSchool
{
    public class DrivingSchoolModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DrivingSchoolConstant.NameMaxLength)]
        [Display(Name = "Име: ")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DrivingSchoolConstant.TownMaxLength)]
        [Display(Name = "Град: ")]
        public string Town { get; set; } = null!;

        [Required]
        [StringLength(DrivingSchoolConstant.AddressMaxLength)]
        [Display(Name = "Адрес: ")]
        public string Address { get; set; } = null!;

        [StringLength(DrivingSchoolConstant.PhoneContactMaxLength)]
        [Display(Name = "Телефон: ")]
        public string? PhoneContact { get; set; }

        [Required]
        [StringLength(DrivingSchoolConstant.LogoImgMaxLength)]
        public string LogoImg { get; set; } = null!;

        [Display(Name = "Обучаващи категории: ")]
        public IEnumerable<string> EducationCategories { get; set; } = new List<string>();
    }
}
