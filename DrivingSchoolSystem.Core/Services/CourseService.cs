using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Course;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext context;

        public CourseService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddCourseAsync(AddCourseModel model)
        {
            var course = new Course()
            {
                AdminId = model.AdminId,
                CategoryId = model.CategoryId,
                StartDate = model.StartDate,
                CreatedOn = DateTime.Now
            };

            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();
        }

        public IEnumerable<CourseModel> GetAllCourses(int drivingSchoolId)
        {
            return context.Courses
                .AsNoTracking()
                .Include(c => c.Admin)
                .Include(c => c.Category)
                .Where(c => c.Admin.DrivingSchoolId == drivingSchoolId)
                .Select(c => new CourseModel()
                {
                    AdminFullName = $"{c.Admin.FirstName} {c.Admin.MiddleName} {c.Admin.LastName}",
                    AdminPhone = c.Admin.PhoneNumber,
                    CreatedOn = c.CreatedOn,
                    StartDate = c.StartDate,
                    CategoryName = c.Category.Name
                });
        }
    }
}
