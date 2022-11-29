using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DrivingSchoolSystem.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext context;

        public AccountService(ApplicationDbContext _context)
        {
            context = _context;
        }

        //public string GetRoleNameById(string userId)
        //{
        //    var userRoles = context.UserRoles
        //        .Where(ur => ur.UserId == userId)
        //        .Select(ur => ur.RoleId);

        //    context.RoleClaims
        //        .Where(r => r.RoleId == userRoles.)
        //        .Select(ur => ur.);
        //}

        public IEnumerable<AccountModel> GetAll()
        {

            return context.Users
                .Select(u => new AccountModel()
                {
                    FullName = $"{u.FirstName} {u.MiddleName} {u.LastName}",
                    //RoleName = u
                    PhoneNumber = u.PhoneNumber
                });
        }
    }
}
