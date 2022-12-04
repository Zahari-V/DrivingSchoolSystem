using DrivingSchoolSystem.Core.Models.Course;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface ICourseService
    {
        IEnumerable<CourseModel> GetAllCourses(int drivingSchoolId);

        Task AddCourseAsync(AddCourseModel model);
    }
}
