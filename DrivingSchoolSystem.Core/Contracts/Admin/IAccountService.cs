using DrivingSchoolSystem.Core.Models.Admin.Account;
using DrivingSchoolSystem.Core.Models.Common;

namespace DrivingSchoolSystem.Core.Contracts.Admin
{
    public interface IAccountService
    {
        IEnumerable<AccountViewModel> GetAllByDrivingSchoolId(int drivingSchoolId);

        Task<IEnumerable<RoleModel>> GetRolesAsync();

        Task<List<CategoryModel>> GetCategoriesAsync();

        Task AddAsync(AccountAddServiceModel model);

        Task<AccountInfoViewModel> GetInfoByIdAsync(Guid accountId, string role);

        Task Delete(Guid id);

        Task<AccountEditServiceModel> GetEditModelByIdAsync(Guid accountId);
        
        Task EditAsync(AccountEditServiceModel model);
    }
}
