using DrivingSchoolSystem.Core.Models.Account;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IAccountService
    {
        IEnumerable<AccountModel> GetAll();

        //string GetRoleNameById(string id);
    }
}
