using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrivingSchoolSystem.Infrastructure.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(CreateUsersRoles());
        }

        private List<IdentityUserRole<string>> CreateUsersRoles()
        {
            var roles = new List<IdentityUserRole<string>>();

            roles.Add(new IdentityUserRole<string>()
            {
                RoleId = "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                UserId = "a98e90bc-1adc-4f87-bb4e-9e12a2d39090"
            });

            roles.Add(new IdentityUserRole<string>()
            {
                RoleId = "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                UserId = "65474606-d7e0-48a6-a6b3-3136c233dd4d"
            });

            return roles;
        }
    }
}
