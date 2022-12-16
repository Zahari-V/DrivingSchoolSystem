using DrivingSchoolSystem.Core.Models.User;
using DrivingSchoolSystem.Infrastructure.Data.Models;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDrivingSchoolModel> GetDrivingSchools();
        
        Task<Account> GetByProvidedEmailAsync(string email, int drivingSchoolId);
        
        Task<Account> GetByIdAsync(Guid accountId);

        Task<bool> IsValidData(RegisterModel model);

        Task<User> GetUserByUsernameAsync(string username);
    }
}
