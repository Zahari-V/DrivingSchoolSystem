using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class Course
    {
        public Course()
        {
            StudentCards = new List<StudentCard>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public int ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public Manager Manager { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public IEnumerable<StudentCard> StudentCards { get; set; }
    }
}
