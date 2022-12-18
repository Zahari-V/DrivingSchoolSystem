using DrivingSchoolSystem.Core.Models.Common;
using DrivingSchoolSystem.Core.Models.StudentCard;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IStudentCardService
    {
        Task<IEnumerable<StudentCardModel>> GetAll(string userId, string role);

        Task AddAsync(StudentCardAddServiceModel model);

        Task<StudentCardAddServiceModel> GetAddModelAsync(string userId);
    }
}
