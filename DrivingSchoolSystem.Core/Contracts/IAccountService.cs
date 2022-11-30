using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Views.Account;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountModel>> GetAllByDrivingSchoolIdAsync(int drivingSchoolId);

        Task<string> GetRoleNameByUserIdAsync(string userId);

        IEnumerable<RoleModel> GetRoles();
    }
}
