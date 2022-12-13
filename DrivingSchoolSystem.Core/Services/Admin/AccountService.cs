using DrivingSchoolSystem.Core.Contracts.Admin;
using DrivingSchoolSystem.Core.Models.Admin.Account;
using DrivingSchoolSystem.Core.Models.Category;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Core.Services.Admin
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext context;

        public AccountService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<AccountModel> GetAllByDrivingSchoolId(int drivingSchoolId, string role)
        {
            var isAdmin = role.ToUpper() == "ADMIN";

            return context.Accounts
                .AsNoTracking()
                .Include(a => a.Role)
                .Include(a => a.DrivingSchool)
                .Where(a => isAdmin ? !a.IsDeleted : a.DrivingSchoolId == drivingSchoolId && !a.IsDeleted)
                .Select(a => new AccountModel()
                {
                    Id = a.Id.ToString(),
                    FullName = $"{a.FirstName} {a.MiddleName} {a.LastName}",
                    RoleName = ConvertRoleNameToBulgarianLang(a.Role.Name),
                    PhoneNumber = a.PhoneNumber,
                    DrivingSchoolName = isAdmin ? a.DrivingSchool.Name : null
                });
        }

        public async Task<IEnumerable<RoleModel>> GetRolesAsync()
        {
            return await context.Roles
                .AsNoTracking()
                .Where(r => r.NormalizedName != "MANAGER" || r.NormalizedName != "ADMIN")
                .Select(r => new RoleModel()
                {
                    Id = r.Id,
                    Name = ConvertRoleNameToBulgarianLang(r.Name)
                }).ToListAsync();
        }

        public async Task AddAccountAsync(AddAccountModel model)
        {
            if (context.Accounts
                .Where(a => a.DrivingSchoolId == model.DrivingSchoolId)
                .Any(a => a.NormalizedEmail == model.Email.ToUpper()))
            {
                throw new ArgumentException("Already has account with this email!!!");
            }

            var account = new Account()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                DrivingSchoolId = model.DrivingSchoolId,
                RoleId = model.RoleId
            };

            await context.Accounts.AddAsync(account);

            var role = await context.Roles
                .AsNoTracking()
                .FirstAsync(r => r.Id == account.RoleId);

            if (role == null)
            {
                throw new NullReferenceException("Role cannot find!");
            }

            if (role.NormalizedName == "STUDENT")
            {
                var student = new Student();

                student.AccountId = account.Id;

                await context.Students.AddAsync(student);
            }
            else if (role.NormalizedName == "INSTRUCTOR")
            {
                var instructor = new Instructor();

                instructor.AccountId = account.Id;

                var categories = model.Categories.Where(c => c.IsMarked).Select(c => new InstructorCategory()
                {
                    Instructor = instructor,
                    CategoryId = c.Id
                });

                await context.InstructorsCategories.AddRangeAsync(categories);

                await context.Instructors.AddAsync(instructor);
            }

            await context.SaveChangesAsync();
        }

        private static string ConvertRoleNameToBulgarianLang(string roleName)
        {
            roleName = roleName.ToUpper();

            if (roleName == "STUDENT")
            {
                roleName = "Ученик";
            }
            else if (roleName == "INSTRUCTOR")
            {
                roleName = "Инструктор";
            }
            else
            {
                roleName = "Мениджър";
            }

            return roleName;
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }
    }
}
