using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.User;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<Account> GetByIdAsync(Guid accountId)
        {
            return await context.Accounts
                .Include(a => a.Role)
                .Include(a => a.DrivingSchool)
                .FirstOrDefaultAsync(a => a.Id == accountId && !a.IsDeleted);
        }

        public async Task<Account> GetByProvidedEmailAsync(string email, int drivingSchoolId)
        {
            return await context.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(a => !a.IsDeleted && a.DrivingSchoolId == drivingSchoolId &&
                a.NormalizedEmail == email.ToUpper());
        }

        public IEnumerable<DrivingSchoolModel> GetDrivingSchools()
        {
            return context.DrivingSchools
                .AsNoTracking()
                .Where(ds => !ds.IsDeleted)
                .Select(ds => new DrivingSchoolModel()
                {
                    Id = ds.Id,
                    Name = ds.Name
                });
        }

        public async Task<bool> IsValidData(RegisterModel model)
        {
            var account = await context.Accounts
                .AsNoTracking()
                .FirstAsync(a => a.Id == model.AccountId && !a.IsDeleted);

            return account.FirstName.ToUpper() == model.FirstName.ToUpper() &&
                account.MiddleName.ToUpper() == model.MiddleName.ToUpper() &&
            account.LastName.ToUpper() == model.LastName.ToUpper() &&
            account.PhoneNumber == model.PhoneNumber;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var account = await context.Accounts
                .AsNoTracking()
                .Include(a => a.User)
                .Include(a => a.DrivingSchool) //This is needed about cookie.
                .FirstOrDefaultAsync(a => a.User != null ?
                a.User.NormalizedUserName == username.ToUpper() && !a.IsDeleted : false);

            if (account == null)
            {
                throw new NullReferenceException("Account cannot find!");
            }

            return account.User;
        }
    }
}
