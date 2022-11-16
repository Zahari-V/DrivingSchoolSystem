using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class DrivingSchoolCategory
    {
        [Required]
        public int DrivingSchoolId { get; set; }

        [ForeignKey(nameof(DrivingSchoolId))]
        public DrivingSchool DrivingSchool { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}
