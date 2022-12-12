using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Admin.Course
{
    public class CourseModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = null!;

        public string AdminFullName { get; set; } = null!;

        [Required]
        public string AdminPhone { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string StartDate { get; set; } = null!;
    }
}
