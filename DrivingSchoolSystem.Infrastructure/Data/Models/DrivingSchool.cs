using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class DrivingSchool
    {
        public DrivingSchool()
        {
            Users = new List<User>();
            EducationCategories = new List<DrivingSchoolCategory>();
        }

        [Key]
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

        public IEnumerable<User> Users { get; set; }
        
        public IEnumerable<DrivingSchoolCategory> EducationCategories { get; set; }
    }
}
