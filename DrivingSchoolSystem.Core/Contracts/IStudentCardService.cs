using DrivingSchoolSystem.Core.Models.Course;
using DrivingSchoolSystem.Core.Models.StudentCard;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IStudentCardService
    {
        IEnumerable<StudentCardModel> GetAll(string userId);

        Task AddStudentCardAsync(AddStudentCardModel model);

        IEnumerable<StudentModel> GetStudents(int drivingSchoolId);

        IEnumerable<CollectionCourseModel> GetCourses(int drivingSchoolId);

        Task<int> GetInstructorId(string userId);
    }
}
