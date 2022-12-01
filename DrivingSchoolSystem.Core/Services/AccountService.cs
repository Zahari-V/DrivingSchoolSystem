using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using DrivingSchoolSystem.Views.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext context;

        public AccountService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<AccountModel>> GetAllByDrivingSchoolIdAsync(int drivingSchoolId)
        {
            return await context.Users
                .AsNoTracking()
                .Include(u => u.UsersRoles)
                .ThenInclude(ur => ur.Role)
                .Where(u => u.DrivingSchoolId == drivingSchoolId)
                .Select(u => new AccountModel()
                {
                    Id = u.Id,
                    FullName = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                    RoleName = ConvertRoleNameToBulgarianLang(u.UsersRoles.First().Role.Name),
                    PhoneNumber = u.PhoneNumber
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<RoleModel>> GetRolesAsync()
        {
            return await context.Roles
                .AsNoTracking()
                .Where(r => r.Name != "Admin")
                .Select(r => new RoleModel()
                {
                    Id = r.Id,
                    Name = ConvertRoleNameToBulgarianLang(r.Name)
                }).ToListAsync();
        }

        public async Task AddAccountAsync(AddModel model)
        {
            var user = new User()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                DrivingSchoolId = model.DrivingSchoolId
            };

            await context.Users.AddAsync(user);

            var userRole = new UserRole()
            {
                UserId = user.Id,
                RoleId = model.RoleId
            };

            await context.UserRoles.AddAsync(userRole);

            var role = await context.Roles.FindAsync(userRole.RoleId);

            if (role == null)
            {
                throw new NullReferenceException("Role is null!");
            }

            if (role.NormalizedName == "STUDENT")
            {
                var student = new Student();

                student.UserId = user.Id;

                await context.Students.AddAsync(student);
            }
            else
            {
                var instructor = new Instructor();

                instructor.UserId = user.Id;

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
                roleName = "Администратор";
            }

            return roleName;
        }

    }
}
