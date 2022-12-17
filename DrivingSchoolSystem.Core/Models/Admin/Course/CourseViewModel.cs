namespace DrivingSchoolSystem.Core.Models.Admin.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string? DrivingSchoolName { get; set; }

        public string CategoryName { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string StartDate { get; set; } = null!;
    }
}
