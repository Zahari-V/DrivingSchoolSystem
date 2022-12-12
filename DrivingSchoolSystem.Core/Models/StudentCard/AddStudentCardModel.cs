using DrivingSchoolSystem.Core.Models.Admin.Course;
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

        public IEnumerable<CollectionCourseModel> Courses { get; set; }
           = new List<CollectionCourseModel>();

        public IEnumerable<StudentModel> Students { get; set; } 
            = new List<StudentModel>();
    }
}
