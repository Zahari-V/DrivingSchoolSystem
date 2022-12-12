using DrivingSchoolSystem.Core.Models.Admin.DrivingSchool;
using DrivingSchoolSystem.Core.Models.Category;
using DrivingSchoolSystem.Core.Models.User;

namespace DrivingSchoolSystem.Core.Contracts.Admin
{
    public interface IDrivingSchoolService
    {
        IEnumerable<DrivingSchoolModel> GetAll();
        
        Task AddAsync(AddDrivingSchoolModel model);

        Task<string> GetNameByIdAsync(int drivingSchoolId);

        Task<DrivingSchoolModel> GetInfoByIdAsync(int drivingSchoolId);

        Task<List<CategoryModel>>
            MarkDrivingSchoolCategoriesAsync(IEnumerable<CategoryModel> drivingSchoolCategories);

        Task EditInfoAsync(DrivingSchoolModel model);
    }
}
