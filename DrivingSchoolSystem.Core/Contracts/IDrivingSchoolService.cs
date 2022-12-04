using DrivingSchoolSystem.Core.Models.Category;
using DrivingSchoolSystem.Core.Models.DrivingSchool;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IDrivingSchoolService
    {
        Task<IEnumerable<DrivingSchoolModel>> GetAll();

        Task<string> GetNameByIdAsync(int drivingSchoolId);

        Task<DrivingSchoolInfoModel> GetInfoByIdAsync(int drivingSchoolId);

        Task<List<CategoryModel>> 
            MarkDrivingSchoolCategoriesAsync(IEnumerable<CategoryModel> drivingSchoolCategories);

        Task EditInfoAsync(DrivingSchoolInfoModel model);
    }
}
