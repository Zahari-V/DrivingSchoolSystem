using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Core.Models.Course;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IStudentCardService
    {
        IEnumerable<CollectionAccountModel> GetAccounts(int drivingSchoolId);

        IEnumerable<CollectionCourseModel> GetCourses(int drivingSchoolId);
    }
}
