using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class DrivingSchool
    {
        public DrivingSchool()
        {
            Users = new List<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(25)]
        public string Town { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Address { get; set; } = null!;

        public IEnumerable<User> Users { get; set; }
    }
}
