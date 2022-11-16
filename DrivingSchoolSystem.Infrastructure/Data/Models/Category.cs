using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class Category
    {
        public Category()
        {
            InstructorsCategories = new List<InstructorCategory>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; } = null!;

        public IEnumerable<InstructorCategory> InstructorsCategories { get; set; }
    }
}
