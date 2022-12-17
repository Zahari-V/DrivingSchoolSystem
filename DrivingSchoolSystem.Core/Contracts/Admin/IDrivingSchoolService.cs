using DrivingSchoolSystem.Core.Models.Admin.DrivingSchool;
using DrivingSchoolSystem.Core.Models.Common;
using DrivingSchoolSystem.Core.Models.User;

namespace DrivingSchoolSystem.Core.Contracts.Admin
{
    public interface IDrivingSchoolService
    {
        IEnumerable<Models.Admin.DrivingSchool.DrivingSchoolModel> GetAll();
        
        Task AddAsync(DrivingSchoolAddServiceModel model);

        Task<Models.Admin.DrivingSchool.DrivingSchoolModel> GetByIdAsync(int drivingSchoolId);


        Task<List<CategoryModel>>
            MarkCategoriesAsync(IEnumerable<CategoryModel> drivingSchoolCategories);

        Task EditAsync(Models.Admin.DrivingSchool.DrivingSchoolModel model);

        Task<List<CategoryModel>> GetCategoriesAsync();

        Task DeleteAsync(int drivingSchoolId);
    }
}
