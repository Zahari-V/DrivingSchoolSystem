using DrivingSchoolSystem.Core.Constants;
using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Common;
using DrivingSchoolSystem.Core.Models.StudentCard;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Configuration;
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

        public async Task AddAsync(StudentCardAddServiceModel model)
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

        public async Task<IEnumerable<StudentCardModel>> GetAll(string userId, string role)
        {
            var studentCards = await context.StudentCards
                .AsNoTracking()
                .Where(sc => !sc.IsDeleted)
                .Include(sc => sc.Student.Account)
                .Include(sc => sc.Student.Account.User)
                .Include(sc => sc.Instructor.Account)
                .Include(sc => sc.Course.Category)
                .Include(sc => sc.Course.Manager)
                .ToListAsync();

            if (role.ToUpper() == RoleConstant.NormalizedStudent)
            {
                var student = await context.Students
                    .AsNoTracking()
                    .Include(s => s.StudentCards)
                    .FirstAsync(a => a.Account.UserId == userId);

                foreach (var card in student.StudentCards)
                {
                    if (!studentCards.Any(sc => sc.Id == card.Id))
                    {
                        studentCards.Remove(card);
                    }
                }
            }
            else if (role.ToUpper() == RoleConstant.NormalizedInstructor)
            {
                var instructor = await context.Instructors
                    .AsNoTracking()
                    .Include(i => i.StudentCards)
                    .FirstAsync(a => a.Account.UserId == userId);

                foreach (var studentCard in instructor.StudentCards)
                {
                    if (!studentCards.Any(sc => sc.Id == studentCard.Id))
                    {
                        studentCards.Remove(studentCard);
                    }
                }
            }
            else if(role.ToUpper() == RoleConstant.NormalizedManager)
            {
                var manager = await context.Managers
                    .AsNoTracking()
                    .FirstAsync(a => a.Account.UserId == userId);

                foreach (var studentCard in studentCards)
                {
                    if (!studentCards.Any(sc => sc.Course.Manager.AccountId == manager.AccountId))
                    {
                        studentCards.Remove(studentCard);
                    }
                }
            }
                
            return studentCards
                .Select(sc => new StudentCardModel()
                {
                    StudentFullName = $"{sc.Student.Account.FirstName} {sc.Student.Account.MiddleName} {sc.Student.Account.LastName}",
                    InstructorFullName = $"{sc.Instructor.Account.FirstName} {sc.Instructor.Account.MiddleName} {sc.Instructor.Account.LastName}",
                    DrivedHours = sc.DrivedHours,
                    CategoryName = sc.Course.Category.Name,
                    CategoryImageUrl = sc.Course.Category.ImageUrl,
                    StudentImageUrl = sc.Student.Account.User.ImageUrl
                });
        }

        public async Task<StudentCardAddServiceModel> GetAddModelAsync(string userId)
        {
            var account = await context.Accounts
                .AsNoTracking()
                .FirstAsync(a => a.UserId == userId);

            var instructor = await context.Instructors
                .AsNoTracking()
                .Include(i => i.InstructorsCategories)
                .FirstAsync(i => i.AccountId == account.Id);

            return new StudentCardAddServiceModel()
            {
                InstructorId = instructor.Id,
                Students = await context.Students
                    .AsNoTracking()
                    .Where(s => s.Account.DrivingSchoolId == account.DrivingSchoolId)
                    .Select(s => new StudentModel()
                    {
                        Id = s.Id,
                        FullName = $"{s.Account.FirstName} {s.Account.MiddleName} {s.Account.LastName}"
                    }).ToListAsync(),
                Courses = context.Courses
                    .AsNoTracking()
                    .Include(c => c.Category)
                    .AsEnumerable()
                    .Where(c => instructor.InstructorsCategories.Any(ic => ic.CategoryId == c.CategoryId))
                    .Select(c => new CourseModel()
                    {
                        Id = c.Id,
                        Name = c.Category.Name,
                        StartDate = c.StartDate.ToString("dd/MM/yyyy")
                    }).ToList()
            };
        }
    }
}
