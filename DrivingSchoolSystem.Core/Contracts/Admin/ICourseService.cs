using DrivingSchoolSystem.Core.Models.Admin.Course;
using DrivingSchoolSystem.Core.Models.Category;

namespace DrivingSchoolSystem.Core.Contracts.Admin
{
    public interface ICourseService
    {
        IEnumerable<CourseViewModel> GetAll(int drivingSchoolId, string role);

        Task AddAsync(CourseServiceModel model);

        Task<IEnumerable<CategoryModel>> GetEducationCategoriesAsync(int drivingSchoolId);

        Task DeleteCourseAsync(int courseId);

        Task<CourseServiceModel> GetByIdAsync(int courseId);

        Task EditAsync(CourseServiceModel model);

        Task<int> GetManagerIdAsync(string userId);
    }
}
