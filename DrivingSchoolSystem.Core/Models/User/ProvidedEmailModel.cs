using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.User
{
    public class ProvidedEmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public int DrivingSchoolId { get; set; }

        public IEnumerable<UserDrivingSchoolModel> DrivingSchools { get; set; } =
            new List<UserDrivingSchoolModel>();
    }
}
