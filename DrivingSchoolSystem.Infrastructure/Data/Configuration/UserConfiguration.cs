using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrivingSchoolSystem.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<User> CreateUsers()
        {
            var users = new List<User>();

            User user = new User()
            {
                Id = "a98e90bc-1adc-4f87-bb4e-9e12a2d39090",
                Email = "avtostart_Vidin@abv.bg",
                NormalizedEmail = "avtostart_Vidin@abv.bg".ToUpper(),
                FirstName = "Георги",
                MiddleName = "Красимиров",
                LastName = "Георгиев",
                DrivingSchoolId = 1,
                PhoneNumber = "0888326291"
            };

            users.Add(user);

            user = new User()
            {
                Id = "65474606-d7e0-48a6-a6b3-3136c233dd4d",
                Email = "rosen85_Sofia@abv.bg",
                NormalizedEmail = "rosen85_Sofia@abv.bg".ToUpper(),
                FirstName = "Петър",
                MiddleName = "Любенов",
                LastName = "Петров",
                DrivingSchoolId = 2,
                PhoneNumber = "0889312141"
            };

            users.Add(user);

            return users;
        }
    }
}
