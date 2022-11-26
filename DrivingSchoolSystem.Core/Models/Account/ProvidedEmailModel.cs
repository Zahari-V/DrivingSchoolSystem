using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Account
{
    public class ProvidedEmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        
        [Required]
        public int DrivingSchoolId { get; set; }

        public IEnumerable<DrivingSchoolModel> DrivingSchools { get; set; } =
            new List<DrivingSchoolModel>();
    }
}
