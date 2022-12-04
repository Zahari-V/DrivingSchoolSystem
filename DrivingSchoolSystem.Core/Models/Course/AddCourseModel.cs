using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchoolSystem.Core.Models.Category;

namespace DrivingSchoolSystem.Core.Models.Course
{
    public class AddCourseModel
    {
        [Required]
        public string AdminId { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
    }
}
