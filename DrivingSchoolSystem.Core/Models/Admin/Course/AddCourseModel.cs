using DrivingSchoolSystem.Core.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Admin.Course
{
    public class AddCourseModel
    {
        [Required]
        public int ManagerId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
