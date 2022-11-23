using DrivingSchoolSystem.Core.Models.Account;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IAccountService
    {
        Task<bool> IsHasEmailAsync(string email);

        Task<User> RegisterUserAsync(RegisterViewModel model);

        Task<User> FindByNameAsync(string username);
    }
}
