using DrivingSchoolSystem.Core.Models.DrivingSchool;
using DrivingSchoolSystem.Core.Models.Common;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IDrivingSchoolService
    {
        Task<IEnumerable<DrivingSchoolModel>> GetAllAsync();

        Task AddAsync(DrivingSchoolServiceModel model);

        Task<DrivingSchoolServiceModel> GetInfoByIdAsync(int drivingSchoolId, string role);


        Task<List<CategoryModel>>
            MarkCategoriesAsync(IEnumerable<CategoryModel> drivingSchoolCategories);

        Task EditAsync(DrivingSchoolServiceModel model, string role);

        Task<List<CategoryModel>> GetCategoriesAsync();

        Task DeleteAsync(int drivingSchoolId);
    }
}
