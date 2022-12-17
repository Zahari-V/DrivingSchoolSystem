using DrivingSchoolSystem.Infrastructure.Data.DataConstants;
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
        [StringLength(DrivingSchoolConstant.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DrivingSchoolConstant.TownMaxLength)]
        public string Town { get; set; } = null!;

        [Required]
        [StringLength(DrivingSchoolConstant.AddressMaxLength)]
        public string Address { get; set; } = null!;

        [StringLength(DrivingSchoolConstant.PhoneContactMaxLength)]
        public string? PhoneContact { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public IEnumerable<Account> Accounts { get; set; }
        
        public IEnumerable<DrivingSchoolCategory> EducationCategories { get; set; }
    }
}
