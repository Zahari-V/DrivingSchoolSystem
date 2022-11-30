using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Views.Account;
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
                .Where(u => u.DrivingSchoolId == drivingSchoolId)
                .Select(u => new AccountModel()
                {
                    Id = u.Id,
                    FullName = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                    PhoneNumber = u.PhoneNumber
                })
                .ToListAsync();
        }

        public async Task<string> GetRoleNameByUserIdAsync(string userId)
        {
            var userRole = await context.UserRoles
                            .Where(ur => ur.UserId == userId)
                            .FirstAsync();

            var roleName = await context.Roles
                .Where(r => r.Id == userRole.RoleId)
                .Select(r => r.Name)
                .FirstAsync();

            return ConverRoleNameToBulgaria(roleName);
        }

        public IEnumerable<RoleModel> GetRoles()
        {
            return context.Roles
                .Where(r => r.Name != "Admin")
                .Select(r => new RoleModel()
                {
                    Id = r.Id,
                    Name = ConverRoleNameToBulgaria(r.Name)
                }).AsEnumerable();
        }

        private static string ConverRoleNameToBulgaria(string roleName)
        {
            if (roleName == "Student")
            {
                roleName = "Ученик";
            }
            else if (roleName == "Instructor")
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
