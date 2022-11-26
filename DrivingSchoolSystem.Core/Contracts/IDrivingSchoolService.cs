using DrivingSchoolSystem.Core.Models;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IDrivingSchoolService
    {
        IEnumerable<DrivingSchoolModel> GetAllDrivingSchools();

        Task<string> GetDrivingSchoolNameAsync(int drivingSchoolId);
    }
}
