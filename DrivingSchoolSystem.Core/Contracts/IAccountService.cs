using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Views.Account;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IAccountService
    {
        IEnumerable<AccountModel> GetAllByDrivingSchoolId(int drivingSchoolId);

        Task<IEnumerable<RoleModel>> GetRolesAsync();

        Task AddAccountAsync(AddModel model);
    }
}
