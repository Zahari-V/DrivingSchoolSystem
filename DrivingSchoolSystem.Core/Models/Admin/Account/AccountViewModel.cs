namespace DrivingSchoolSystem.Core.Models.Admin.Account
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = null!;

        public string RoleName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? DrivingSchoolName { get; set; }
    }
}
