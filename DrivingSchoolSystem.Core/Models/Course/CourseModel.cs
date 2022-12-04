using DrivingSchoolSystem.Core.Models.Category;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Course
{
    public class CourseModel
    {
        public string CategoryName { get; set; } = null!;

        public string AdminFullName { get; set; } = null!;

        [Required]
        public string AdminPhone { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string StartDate { get; set; } = null!;
    }
}
