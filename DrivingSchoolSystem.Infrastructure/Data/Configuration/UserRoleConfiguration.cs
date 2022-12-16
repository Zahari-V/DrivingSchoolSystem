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
            var usersRoles = new List<IdentityUserRole<string>>();

            usersRoles.Add(new IdentityUserRole<string>()
            {
                RoleId = "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                UserId = "5b837013-946c-406e-8fce-9631c2844350"
            });

            return usersRoles;
        }
    }
}
