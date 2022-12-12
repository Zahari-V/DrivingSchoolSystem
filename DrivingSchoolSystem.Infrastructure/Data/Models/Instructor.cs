using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class Instructor
    {
        public Instructor()
        {
            InstructorsCategories = new List<InstructorCategory>();
            StudentCards = new List<StudentCard>();
            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public Guid AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; } = null!;

        public IEnumerable<InstructorCategory> InstructorsCategories { get; set; }
        
        public IEnumerable<StudentCard> StudentCards { get; set; }
    }
}
