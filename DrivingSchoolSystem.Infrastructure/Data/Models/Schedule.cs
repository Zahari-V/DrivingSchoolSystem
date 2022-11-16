using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentCardId { get; set; }

        [ForeignKey(nameof(StudentCardId))]
        public StudentCard StudentCard { get; set; } = null!;

        [Required]
        public DateTime DateForDrive { get; set; }

        [Required]
        public bool IsDone { get; set; }
    }
}
