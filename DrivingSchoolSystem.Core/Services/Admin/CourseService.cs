using DrivingSchoolSystem.Core.Contracts.Admin;
using DrivingSchoolSystem.Core.Models.Admin.Course;
using DrivingSchoolSystem.Core.Models.Category;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Core.Services.Admin
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext context;

        public CourseService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddAsync(CourseServiceModel model)
        {
            var course = new Course()
            {
                ManagerId = model.ManagerId,
                CategoryId = model.CategoryId,
                StartDate = model.StartDate,
                CreatedOn = DateTime.Now
            };

            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await context.Courses
                .Include(c => c.StudentCards)
                .FirstAsync(c => c.Id == courseId);

            if (course == null)
            {
                throw new NullReferenceException("Course cannot find!");
            }

            course.IsDeleted = true;

            foreach (var studentCard  in course.StudentCards)
            {
                studentCard.IsDeleted = true;
            }

            await context.SaveChangesAsync();
        }

        public async Task<CourseServiceModel> GetByIdAsync(int courseId)
        {
            var course = await context.Courses
                .AsNoTracking()
                .FirstAsync(c => c.Id == courseId);

            return new CourseServiceModel()
            {
                Id = course.Id,
                StartDate = course.StartDate,
                CategoryId = course.CategoryId
            };
        }

        public IEnumerable<CourseViewModel> GetAll(int drivingSchoolId, string role)
        {
            var isAdmin = role.ToUpper() == "ADMIN";

            return context.Courses
                .AsNoTracking()
                .Include(c => c.Manager.Account.DrivingSchool)
                .Include(c => c.Category)
                .Where(c => isAdmin ? !c.IsDeleted :
                c.Manager.Account.DrivingSchool.Id == drivingSchoolId && !c.IsDeleted)
                .Select(c => new CourseViewModel()
                {
                    Id = c.Id,
                    DrivingSchoolName = isAdmin ? c.Manager.Account.DrivingSchool.Name : null,
                    CreatedOn = c.CreatedOn,
                    StartDate = c.StartDate.ToString("dd/MM/yyyy"),
                    CategoryName = c.Category.Name
                });
        }

        public async Task<IEnumerable<CategoryModel>> GetEducationCategoriesAsync(int drivingSchoolId)
        {
            var drivingSchool = await context.DrivingSchools
                .AsNoTracking()
                .Include(ds => ds.EducationCategories)
                .ThenInclude(ec => ec.Category)
                .FirstAsync(ds => ds.Id == drivingSchoolId);

            return drivingSchool.EducationCategories
                .Select(ec => new CategoryModel()
                {
                    Id = ec.Category.Id,
                    Name = ec.Category.Name
                }).ToList();
        }

        public async Task EditAsync(CourseServiceModel model)
        {
            var course = await context.Courses.FindAsync(model.Id);

            if (course == null)
            {
                throw new NullReferenceException("Course cannot find!");
            }

            course.ManagerId = model.ManagerId;
            course.CategoryId = model.CategoryId;
            course.StartDate = model.StartDate;

            await context.SaveChangesAsync();
        }

        public async Task<int> GetManagerIdAsync(string userId)
        {
            var accountId = await context.Accounts
                .AsNoTracking()
                .Where(a => a.UserId == userId)
                .Select(a => a.Id)
                .FirstAsync();

            return await context.Managers
                .AsNoTracking()
                .Where(m => m.AccountId == accountId)
                .Select(m => m.Id)
                .FirstAsync();
        }
    }
}
