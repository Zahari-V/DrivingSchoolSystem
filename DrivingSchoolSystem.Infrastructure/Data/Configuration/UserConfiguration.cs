using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var user = new User()
            {
                Id = "5b837013-946c-406e-8fce-9631c2844350",
                UserName = "Admin",
                NormalizedUserName = "Admin".ToUpper(),
                Email = "admin@abv.bg",
                NormalizedEmail = "admin@abv.bg".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "0889324353"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "user123");

            users.Add(user);

            return users;
        }
    }
}
