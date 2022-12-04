using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Core.Models.Category;
using DrivingSchoolSystem.Views.Account;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IAccountService
    {
        IEnumerable<AccountModel> GetAllByDrivingSchoolId(int drivingSchoolId);

        Task<IEnumerable<RoleModel>> GetRolesAsync();
        
        Task<List<CategoryModel>> GetCategoriesAsync();

        Task AddAccountAsync(AddAccountModel model);
    }
}
