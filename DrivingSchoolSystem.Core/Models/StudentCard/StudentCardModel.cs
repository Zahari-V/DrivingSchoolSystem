using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.StudentCard
{
    public class StudentCardModel
    {
        public string CategoryName { get; set; } = null!;

        public string StudentImageUrl { get; set; } = null!;
        
        public string CategoryImageUrl { get; set; } = null!;

        [Display(Name = "Име: ")]
        public string StudentFullName { get; set; } = null!;

        [Display(Name = "Инструктор: ")]
        public string InstructorFullName { get; set; } = null!;

        [Display(Name = "Изкарани часове: ")]
        public int DrivedHours { get; set; }
    }
}
