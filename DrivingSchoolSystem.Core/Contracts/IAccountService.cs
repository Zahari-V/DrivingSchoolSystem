using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Views.Account;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountModel>> GetAllByDrivingSchoolIdAsync(int drivingSchoolId);

        Task<IEnumerable<RoleModel>> GetRolesAsync();

        Task AddAccountAsync(AddModel model);
    }
}
