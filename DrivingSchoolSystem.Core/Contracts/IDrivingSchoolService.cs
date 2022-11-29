using DrivingSchoolSystem.Core.Models.DrivingSchool;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IDrivingSchoolService
    {
        IEnumerable<DrivingSchoolModel> GetAllDrivingSchools();

        Task<string> GetDrivingSchoolNameAsync(int drivingSchoolId);
    }
}
