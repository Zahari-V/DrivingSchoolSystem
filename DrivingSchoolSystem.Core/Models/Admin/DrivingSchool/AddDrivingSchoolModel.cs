using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchoolSystem.Core.Models.Admin.DrivingSchool
{
    public class AddDrivingSchoolModel
    {
        [Required]
        public DrivingSchoolModel DrivingSchool { get; set; } = null!;

        [Required]
        public ManagerModel Manager { get; set; } = null!;
    }
}
