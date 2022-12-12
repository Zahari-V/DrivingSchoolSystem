using DrivingSchoolSystem.Core.Models.Admin.Account;
using DrivingSchoolSystem.Core.Models.Category;

namespace DrivingSchoolSystem.Core.Contracts.Admin
{
    public interface IAccountService
    {
        IEnumerable<AccountModel> GetAllByDrivingSchoolId(int drivingSchoolId, string role);

        Task<IEnumerable<RoleModel>> GetRolesAsync();

        Task<List<CategoryModel>> GetCategoriesAsync();

        Task AddAccountAsync(AddAccountModel model);
    }
}
