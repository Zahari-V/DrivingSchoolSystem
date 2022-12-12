using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class StudentCard
    {
        public StudentCard()
        {
            Schedules = new List<Schedule>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;

        [Required]
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = null!;

        [Required]
        public int InstructorId { get; set; }

        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; } = null!;

        [Required]
        public int DrivedHours { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public IEnumerable<Schedule> Schedules { get; set; }
    }
}
