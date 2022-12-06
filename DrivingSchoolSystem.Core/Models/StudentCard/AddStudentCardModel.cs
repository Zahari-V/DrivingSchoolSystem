using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Core.Models.Course;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.StudentCard
{
    public class AddStudentCardModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int InstructorId { get; set; }

        public IEnumerable<CollectionCourseModel> Courses { get; set; }
           = new List<CollectionCourseModel>();

        public IEnumerable<CollectionAccountModel> Accounts { get; set; } 
            = new List<CollectionAccountModel>();
    }
}
