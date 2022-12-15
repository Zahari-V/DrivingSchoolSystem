using DrivingSchoolSystem.Core.Models.Admin.DrivingSchool;
using DrivingSchoolSystem.Core.Models.Category;
using DrivingSchoolSystem.Core.Models.User;

namespace DrivingSchoolSystem.Core.Contracts.Admin
{
    public interface IDrivingSchoolService
    {
        IEnumerable<DrivingSchoolModel> GetAll();
        
        Task AddAsync(AddDrivingSchoolModel model);

        Task<DrivingSchoolModel> GetByIdAsync(int drivingSchoolId);


        Task<List<CategoryModel>>
            MarkCategoriesAsync(IEnumerable<CategoryModel> drivingSchoolCategories);

        Task EditAsync(DrivingSchoolModel model);

        Task<List<CategoryModel>> GetCategoriesAsync();

        Task DeleteAsync(int drivingSchoolId);
    }
}
