using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DrivingSchoolSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        
        public DbSet<StudentCard> StudentCards { get; set; }
        
        public DbSet<Category> Categories { get; set; }
       
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<DrivingSchool> DrivingSchools { get; set; }
        
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Instructor> Instructors { get; set; }
        
        public DbSet<InstructorCategory> InstructorsCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<InstructorCategory>()
                .HasKey(ic => new { ic.InstructorId , ic.CategoryId });

            builder.Entity<Schedule>()
                .Property(s => s.IsDone)
                .HasDefaultValue(false);

            builder.Entity<Student>(s =>
            {
                s.Property(s => s.BirthDate).HasColumnType("date");
            });

            builder.Entity<StudentCard>(sc =>
            {
                sc.Property(sc => sc.DrivedHours).HasDefaultValue(0);
                sc.HasOne(sc => sc.Instructor).WithMany(i => i.StudentCards).OnDelete(DeleteBehavior.Restrict);
                sc.HasOne(sc => sc.Student).WithMany(s => s.StudentCards).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}