using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Account;
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

        public IEnumerable<CollectionAccountModel> GetAccounts(int drivingSchoolId)
        {
            return context.Users
                .AsNoTracking()
                .Where(u => u.DrivingSchoolId == drivingSchoolId)
                .Select(u => new CollectionAccountModel()
                {
                    Id = u.Id,
                    FullName = $"{u.FirstName} {u.MiddleName} {u.LastName}"
                });
        }

        public IEnumerable<StudentCardModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CollectionCourseModel> GetCourses(int drivingSchoolId)
        {
            return context.Courses
              .AsNoTracking()
              .Include(c => c.Admin)
              .Include(c => c.Category)
              .Where(c => c.Admin.DrivingSchoolId == drivingSchoolId)
              .Select(c => new CollectionCourseModel()
              {
                  Id = c.Id,
                  Name = c.Category.Name
              });
        }
    }
}
