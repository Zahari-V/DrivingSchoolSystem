using DrivingSchoolSystem.Infrastructure.Data.DataConstants;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class Category
    {
        public Category()
        {
            InstructorsCategories = new List<InstructorCategory>();
            DrivingSchoolsCategories = new List<DrivingSchoolCategory>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryConstant.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(CategoryConstant.ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        public IEnumerable<InstructorCategory> InstructorsCategories { get; set; }
        
        public IEnumerable<DrivingSchoolCategory> DrivingSchoolsCategories { get; set; }
    }
}
