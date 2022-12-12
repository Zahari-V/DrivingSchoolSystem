using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Admin.Course;
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
                .Include(s => s.Account)
                .Where(s => s.Account.DrivingSchoolId == drivingSchoolId)
                .Select(s => new StudentModel()
                {
                    Id = s.Id,
                    FullName = $"{s.Account.FirstName} {s.Account.MiddleName} {s.Account.LastName}"
                });
        }

        public IEnumerable<CollectionCourseModel> GetCourses(int drivingSchoolId)
        {
            return context.Courses
              .AsNoTracking()
              .Include(c => c.Manager)
              .ThenInclude(m => m.Account)
              .Include(c => c.Category)
              .ThenInclude(cg => cg.DrivingSchoolsCategories)
              .Where(c => c.Manager.Account.DrivingSchoolId == drivingSchoolId && c.StartDate > DateTime.Now)
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
                .Include(i => i.Account)
                .FirstAsync(i => i.Account.UserId == userId);

            return instructor.Id;
        }

        public IEnumerable<StudentCardModel> GetAll(string userId, string role)
        {
            return context.StudentCards
                .AsNoTracking()
                .Include(sc => sc.Student.Account)
                //.ThenInclude(s => s.Account)
                .Include(sc => sc.Instructor.Account)
                //.ThenInclude(i => i.Account)
                .Include(sc => sc.Course.Category)
                .Include(sc => sc.Course.Manager.Account)
                //.ThenInclude(c => c.Category)
                //.ThenInclude(c => c.Category)
                .Where(sc => sc.Student.Account.UserId == userId
                || sc.Instructor.Account.UserId == userId || sc.Course.Manager.Account.UserId == userId)
                .Select(sc => new StudentCardModel()
                {
                    StudentFullName = $"{sc.Student.Account.FirstName} {sc.Student.Account.MiddleName} {sc.Student.Account.LastName}",
                    //InstructorFullName = $"{sc.Instructor.User.FirstName} {sc.Instructor.User.MiddleName} {sc.Instructor.User.LastName}",
                    //DrivedHours = sc.DrivedHours,
                    //CategoryName = sc.Course.Category.Name,
                    //ImageUrl = role.ToUpper() == "STUDENT" ? sc.Course.Category.ImageUrl : sc.Instructor.User.ImageUrl
                });
        }
    }
}
