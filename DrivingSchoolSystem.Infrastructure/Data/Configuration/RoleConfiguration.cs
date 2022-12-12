using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrivingSchoolSystem.Infrastructure.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(CreateRoles());
        }

        private List<IdentityRole> CreateRoles()
        {
            var roles = new List<IdentityRole>();

            roles.Add(new IdentityRole()
            {
                Id = "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            });

            roles.Add(new IdentityRole()
            {
                Id = "42196e3c-e72a-4778-994f-36c85380e060",
                Name = "Instructor",
                NormalizedName = "Instructor".ToUpper()
            });

            roles.Add(new IdentityRole()
            {
                Id = "9b325984-c63f-4dec-a00b-eeaab3d34035",
                Name = "Student",
                NormalizedName = "Student".ToUpper()
            });

            roles.Add(new IdentityRole()
            {
                Id = "f33ee30d-f3c5-4243-b4b8-a7fa240c3707",
                Name = "Manager",
                NormalizedName = "Manager".ToUpper()
            });

            return roles;
        }
    }
}
