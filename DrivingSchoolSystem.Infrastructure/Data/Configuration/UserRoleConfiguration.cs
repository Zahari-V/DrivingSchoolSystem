using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrivingSchoolSystem.Infrastructure.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(CreateUsersRoles());
        }

        private List<UserRole> CreateUsersRoles()
        {
            var usersRoles = new List<UserRole>();

            usersRoles.Add(new UserRole()
            {
                RoleId = "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                UserId = "a98e90bc-1adc-4f87-bb4e-9e12a2d39090"
            });

            usersRoles.Add(new UserRole()
            {
                RoleId = "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                UserId = "65474606-d7e0-48a6-a6b3-3136c233dd4d"
            });

            return usersRoles;
        }
    }
}
