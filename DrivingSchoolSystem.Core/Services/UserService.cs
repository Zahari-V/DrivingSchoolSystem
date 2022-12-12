using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.User;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
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

        public async Task<Account> GetByIdAsync(Guid guid)
        {
            return await context.Accounts
                .Include(a => a.Role)
                .Include(a => a.DrivingSchool)
                .FirstOrDefaultAsync(a => a.Id == guid && !a.IsDeleted);
        }

        public async Task<Account> GetAsync(int drivingSchoolId, string email)
        {
            return await context.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(a => !a.IsDeleted && a.DrivingSchoolId == drivingSchoolId &&
                a.NormalizedEmail == email.ToUpper());
        }

        public IEnumerable<UserDrivingSchoolModel> GetDrivingSchools()
        {
            return context.DrivingSchools
                .AsNoTracking()
                .Where(ds => !ds.IsDeleted)
                .Select(ds => new UserDrivingSchoolModel()
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

        public async Task RegisterAccount(Guid accountId)
        {
            var account = await context.Accounts.FirstAsync(a => a.Id == accountId);

            account.IsRegistered = true;

            await context.SaveChangesAsync();
        }
    }
}
