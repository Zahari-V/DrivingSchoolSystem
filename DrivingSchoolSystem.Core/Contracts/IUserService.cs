using DrivingSchoolSystem.Core.Models.User;
using DrivingSchoolSystem.Infrastructure.Data.Models;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDrivingSchoolModel> GetDrivingSchools();
        
        Task<Account> GetAsync(int drivingSchoolId, string email);
        
        Task<Account> GetByIdAsync(Guid accountId);

        Task<bool> IsValidData(RegisterModel model);
        
        Task RegisterAccount(Guid accountId);
    }
}
