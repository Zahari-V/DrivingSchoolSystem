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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(CreateAccounts());
        }

        private List<Account> CreateAccounts()
        {
            var accounts = new List<Account>();

            accounts.Add(new Account()
            {
                Id = Guid.Parse("db4b5796-75a6-4c96-9c1b-98ee8dbee27d"),
                FirstName = "Петър",
                MiddleName = "Петров",
                LastName = "Тодоров",
                Email = "admin@abv.bg",
                NormalizedEmail = "admin@abv.bg".ToUpper(),
                PhoneNumber = "0889324353",
                UserId = "5b837013-946c-406e-8fce-9631c2844350",
                RoleId = "b4656095-c561-4bfa-a5ad-08f7678af1bf",
                DrivingSchoolId = null
            });

            return accounts;
        }
    }
}
