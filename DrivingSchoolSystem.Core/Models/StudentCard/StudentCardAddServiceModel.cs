using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.StudentCard
{
    public class StudentCardAddServiceModel
    {

        [Required]
        public int InstructorId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();

        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
    }
}
