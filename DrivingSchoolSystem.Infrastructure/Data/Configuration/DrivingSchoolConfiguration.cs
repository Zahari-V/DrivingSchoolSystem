using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrivingSchoolSystem.Infrastructure.Data.Configuration
{
    public class DrivingSchoolConfiguration : IEntityTypeConfiguration<DrivingSchool>
    {
        public void Configure(EntityTypeBuilder<DrivingSchool> builder)
        {
            builder.HasData(new DrivingSchool()
            {
                Id = 1,
                Name = "\"Автостарт - Великин\" ЕООД",
                Town = "Видин",
                Address = "ул. „Железничарска“ 34",
                PhoneContact = "0888129915"
            });
        }
    }
}
