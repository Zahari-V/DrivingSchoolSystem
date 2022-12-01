using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrivingSchoolSystem.Infrastructure.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(CreateRoles());
        }

        private List<Role> CreateRoles()
        {
            var roles = new List<Role>();

            roles.Add(new Role()
            {
                Id = "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            });

            roles.Add(new Role()
            {
                Id = "42196e3c-e72a-4778-994f-36c85380e060",
                Name = "Instructor",
                NormalizedName = "Instructor".ToUpper()
            });

            roles.Add(new Role()
            {
                Id = "9b325984-c63f-4dec-a00b-eeaab3d34035",
                Name = "Student",
                NormalizedName = "Student".ToUpper()
            });

            return roles;
        }
    }
}
