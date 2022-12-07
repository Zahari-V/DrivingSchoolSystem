using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Core.Models.Course;
using DrivingSchoolSystem.Core.Models.StudentCard;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IStudentCardService
    {
        IEnumerable<StudentCardModel> GetAll();

        Task AddStudentCardAsync(AddStudentCardModel model);

        IEnumerable<CollectionAccountModel> GetAccounts(int drivingSchoolId);

        IEnumerable<CollectionCourseModel> GetCourses(int drivingSchoolId);
    }
}
