using DrivingSchoolSystem.Core.Models.Admin.DrivingSchool;
using DrivingSchoolSystem.Core.Models.Common;

namespace DrivingSchoolSystem.Core.Contracts.Admin
{
    public interface IDrivingSchoolService
    {
        IEnumerable<DrivingSchoolModel> GetAll();
        
        Task AddAsync(DrivingSchoolServiceModel model);

        Task<DrivingSchoolServiceModel> GetInfoByIdAsync(int drivingSchoolId, string role);


        Task<List<CategoryModel>>
            MarkCategoriesAsync(IEnumerable<CategoryModel> drivingSchoolCategories);

        Task EditAsync(DrivingSchoolServiceModel model, string role);

        Task<List<CategoryModel>> GetCategoriesAsync();

        Task DeleteAsync(int drivingSchoolId);
    }
}
