using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class Manager
    {
        public Manager()
        {
            Courses = new List<Course>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public Guid AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; } = null!;

        public IEnumerable<Course> Courses { get; set; }
    }
}
