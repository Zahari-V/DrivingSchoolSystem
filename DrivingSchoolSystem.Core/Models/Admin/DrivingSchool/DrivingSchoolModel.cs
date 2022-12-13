using DrivingSchoolSystem.Core.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Admin.DrivingSchool
{
    public class DrivingSchoolModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(25)]
        public string Town { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Address { get; set; } = null!;

        [StringLength(15)]
        public string? PhoneContact { get; set; }

        public List<CategoryModel> EducationCategories { get; set; } = new List<CategoryModel>();
    }
}
