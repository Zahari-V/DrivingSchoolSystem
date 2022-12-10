using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Course;
using DrivingSchoolSystem.Core.Models.StudentCard;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Core.Services
{
    public class StudentCardService : IStudentCardService
    {
        private readonly ApplicationDbContext context;

        public StudentCardService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddStudentCardAsync(AddStudentCardModel model)
        {
            StudentCard studentCard = new StudentCard()
            {
                InstructorId = model.InstructorId,
                StudentId = model.StudentId,
                CourseId = model.CourseId
            };

            await context.StudentCards.AddAsync(studentCard);
            await context.SaveChangesAsync();
        }

        public IEnumerable<StudentModel> GetStudents(int drivingSchoolId)
        {
            return context.Students
                .AsNoTracking()
                .Include(s => s.User)
                .Where(s => s.User.DrivingSchoolId == drivingSchoolId)
                .Select(s => new StudentModel()
                {
                    Id = s.Id,
                    FullName = $"{s.User.FirstName} {s.User.MiddleName} {s.User.LastName}"
                });
        }

        public IEnumerable<CollectionCourseModel> GetCourses(int drivingSchoolId)
        {
            return context.Courses
              .AsNoTracking()
              .Include(c => c.Admin)
              .Include(c => c.Category)
              .ThenInclude(cg => cg.DrivingSchoolsCategories)
              .Where(c => c.Admin.DrivingSchoolId == drivingSchoolId && c.StartDate > DateTime.Now)
              .Select(c => new CollectionCourseModel()
              {
                  Id = c.Id,
                  Name = c.Category.Name,
                  StartDate = c.StartDate.ToString("dd/MM/yyyy"),
              });
        }

        public async Task<int> GetInstructorId(string userId)
        {
            var instructor = await context.Instructors
                .AsNoTracking()
                .FirstAsync(i => i.UserId == userId);

            return instructor.Id;
        }

        public IEnumerable<StudentCardModel> GetAll(string userId, string role)
        {
            return context.StudentCards
                .AsNoTracking()
                .Include(sc => sc.Student)
                .Include(sc => sc.Instructor)
                .ThenInclude(i => i.User)
                .Include(sc => sc.Course)
                .ThenInclude(c => c.Category)
                .Where(sc => sc.Student.UserId == userId
                || sc.Instructor.UserId == userId || sc.Course.AdminId == userId)
                .Select(sc => new StudentCardModel()
                {
                    StudentFullName = $"{sc.Student.User.FirstName} {sc.Student.User.MiddleName} {sc.Student.User.LastName}",
                    InstructorFullName = $"{sc.Instructor.User.FirstName} {sc.Instructor.User.MiddleName} {sc.Instructor.User.LastName}",
                    DrivedHours = sc.DrivedHours,
                    CategoryName = sc.Course.Category.Name,
                    ImageUrl = role.ToUpper() == "STUDENT" ? sc.Course.Category.ImageUrl : sc.Instructor.User.ImageUrl
                });
        }
    }
}
