using DrivingSchoolSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchoolSystem.Core.Models.StudentCard
{
    public class StudentCardModel
    {
        public string CategoryName { get; set; } = null!;

        public string CategoryImageUrl { get; set; } = null!;

        [Display(Name = "Инструктор: ")]
        public string InstructorFullName { get; set; } = null!;

        [Display(Name = "Брой изкарани часове: ")]
        public int DrivedHours { get; set; }
    }
}
