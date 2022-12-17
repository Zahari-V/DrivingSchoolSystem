using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.StudentCard
{
    public class AddStudentCardModel
    {

        [Required]
        public int InstructorId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        public IEnumerable<CourseModel> Courses { get; set; }
           = new List<CourseModel>();

        public IEnumerable<StudentModel> Students { get; set; } 
            = new List<StudentModel>();
    }
}
