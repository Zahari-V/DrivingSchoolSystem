using DrivingSchoolSystem.Core.Models.Course;
using DrivingSchoolSystem.Core.Models.Common;

namespace DrivingSchoolSystem.Core.Contracts
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
