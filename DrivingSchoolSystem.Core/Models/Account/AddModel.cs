using DrivingSchoolSystem.Views.Account;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Account
{
    public class AddModel
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(30)]
        public string MiddleName { get; set; } = null!;

        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public int DrivingSchoolId { get; set; }

        public string RoleId { get; set; } = null!;

        public IEnumerable<RoleModel> Roles { get; set; } = new List<RoleModel>();
    }
}
