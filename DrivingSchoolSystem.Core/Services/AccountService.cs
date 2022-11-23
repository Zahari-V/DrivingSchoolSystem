using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchoolSystem.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext context;

        public AccountService(UserManager<User> _userManager, ApplicationDbContext _context)
        {
            userManager = _userManager;
            context = _context;
        }

        public async Task<User> RegisterUserAsync(RegisterViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                throw new NullReferenceException("User is null!");
            }

            var hasher = new PasswordHasher<User>();

            user.UserName = model.Username;
            user.PasswordHash = hasher.HashPassword(user, model.Password);

            return user;
        }

        public async Task<User> FindByNameAsync(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        public async Task<bool> IsHasEmailAsync(string email)
        {           
            return await context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
