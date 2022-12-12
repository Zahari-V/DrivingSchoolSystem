using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class DrivingSchool
    {
        public DrivingSchool()
        {
            Accounts = new List<Account>();
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

        [Required]
        public bool IsDeleted { get; set; }

        public IEnumerable<Account> Accounts { get; set; }
        
        public IEnumerable<DrivingSchoolCategory> EducationCategories { get; set; }
    }
}
