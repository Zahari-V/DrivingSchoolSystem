using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
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
            var hasher = new PasswordHasher<User>();

            User user = new User()
            {
                Id = "a98e90bc-1adc-4f87-bb4e-9e12a2d39090",
                UserName = "Admin-Avtostart-Vidin",
                NormalizedUserName = "ADMIN-AVTOSTART-VIDIN",
                Email = "avtostart_Vidin@abv.bg",
                NormalizedEmail = "AVTOSTART_VIDIN@ABV.BG",
                FirstName = "Georgi",
                MiddleName = "Krasimirov",
                LastName = "Georgiev",
                ImageUrl = "https://imgs.search.brave.com/toKRUCUyE8TM1qEktBt5ukJhyHFq1j4ZJ555sHuxI7I/rs:fit:1200:1200:1/g:ce/aHR0cDovL3BsdXNw/bmcuY29tL2ltZy1w/bmcvdXNlci1wbmct/aWNvbi15b3VuZy11/c2VyLWljb24tMjQw/MC5wbmc",
                DrivingSchoolId = 1,
                PhoneNumber = "0888326291"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "user123");

            users.Add(user);

            user = new User()
            {
                Id = "65474606-d7e0-48a6-a6b3-3136c233dd4d",
                UserName = "Admin-Rosen85-Sofia",
                NormalizedUserName = "ADMIN-ROSEN85-SOFIA",
                Email = "rosen85_Sofia@abv.bg",
                NormalizedEmail = "ROSEN85_SOFIA@ABV.BG",
                FirstName = "Petar",
                MiddleName = "Lubenov",
                LastName = "Petrov",
                ImageUrl = "https://imgs.search.brave.com/7RoZdgbwxvnACxZN74kJ9Cc7y2r9peTmTq-0bEu7zmE/rs:fit:1200:1024:1/g:ce/aHR0cDovL3d3dy5w/c2RncmFwaGljcy5j/b20vZmlsZS91c2Vy/LWljb24uanBn",
                DrivingSchoolId = 2,
                PhoneNumber = "0889312141"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "user123");

            users.Add(user);

            return users;
        }
    }
}
