using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.StudentCard
{
    public class StudentCardModel
    {
        public string CategoryName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Име: ")]
        public string StudentFullName { get; set; } = null!;

        [Display(Name = "Инструктор име: ")]
        public string InstructorFullName { get; set; } = null!;

        [Display(Name = "Брой изкарани часове: ")]
        public int DrivedHours { get; set; }

    }
}
