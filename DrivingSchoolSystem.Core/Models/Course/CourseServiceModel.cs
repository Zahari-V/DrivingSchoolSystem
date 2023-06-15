using DrivingSchoolSystem.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Course
{
    public class CourseServiceModel
    {
        public int? Id { get; set; }

        [Required]
        public int ManagerId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
