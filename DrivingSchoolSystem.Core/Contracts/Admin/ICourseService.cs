using DrivingSchoolSystem.Core.Models.Admin.Course;
using DrivingSchoolSystem.Core.Models.Category;

namespace DrivingSchoolSystem.Core.Contracts.Admin
{
    public interface ICourseService
    {
        IEnumerable<CourseModel> GetAllCourses(int drivingSchoolId, string role);

        Task AddCourseAsync(AddCourseModel model);

        Task<IEnumerable<CategoryModel>> GetEducationCategoriesAsync(int drivingSchoolId);

        Task DeleteCourseAsync(int courseId);

        Task<EditCourseModel> GetEditModelByIdAsync(int courseId);

        Task EditAsync(EditCourseModel model);

        Task<int> GetManagerIdAsync(string userId);
    }
}
