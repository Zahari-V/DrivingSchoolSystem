using DrivingSchoolSystem.Infrastructure.Data.Configuration;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; } = null!;
        
        public DbSet<StudentCard> StudentCards { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Schedule> Schedules { get; set; } = null!;

        public DbSet<DrivingSchool> DrivingSchools { get; set; } = null!;

        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Instructor> Instructors { get; set; } = null!;

        public DbSet<InstructorCategory> InstructorsCategories { get; set; } = null!;

        public DbSet<DrivingSchoolCategory> DrivingSchoolsCategories { get; set; } = null!;

        public DbSet<Account> Accounts { get; set; } = null!;

        public DbSet<Manager> Managers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(u =>
            {
                u.Property(u => u.UserName).HasMaxLength(25).IsRequired();
                u.Property(u => u.NormalizedUserName).HasMaxLength(25);
                u.Property(u => u.Email).HasMaxLength(25).IsRequired();
                u.Property(u => u.NormalizedEmail).HasMaxLength(25);
                u.Property(u => u.PhoneNumber).HasMaxLength(12).IsRequired();
                u.Property(u => u.ImageUrl).HasDefaultValue("https://imgs.search.brave.com/G4V3oO6hyzU7zIFGh46tw2rNQQr1sCgN0b2sygyE3-Q/rs:fit:820:641:1/g:ce/aHR0cHM6Ly93d3cu/cG5na2l0LmNvbS9w/bmcvZGV0YWlsLzI4/MS0yODEyODIxX3Vz/ZXItYWNjb3VudC1t/YW5hZ2VtZW50LWxv/Z28tdXNlci1pY29u/LXBuZy5wbmc");
            });

            builder.Entity<DrivingSchool>(ds =>
            {
                ds.Property(ds => ds.IsDeleted).HasDefaultValue(false);
            });

            builder.Entity<Account>(a =>
            {
                a.Property(a => a.IsDeleted).HasDefaultValue(false);
                a.Property(a => a.UserId).HasDefaultValue(null);
                a.Property(a => a.DrivingSchoolId).HasDefaultValue(null);
                a.HasOne(a => a.DrivingSchool).WithMany(ds => ds.Accounts);
                a.HasOne(a => a.User).WithOne(u => u.Account).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<InstructorCategory>()
                .HasKey(ic => new { ic.InstructorId , ic.CategoryId });

            builder.Entity<DrivingSchoolCategory>()
                .HasKey(dsc => new { dsc.DrivingSchoolId, dsc.CategoryId });

            builder.Entity<Schedule>()
                .Property(s => s.IsDone)
                .HasDefaultValue(false);

            builder.Entity<Course>(c =>
            {
                c.Property(c => c.StartDate).HasColumnType("date");
                c.Property(c => c.IsDeleted).HasDefaultValue(false);
            });

            builder.Entity<StudentCard>(sc =>
            {
                sc.Property(sc => sc.DrivedHours).HasDefaultValue(0);
                sc.HasOne(sc => sc.Instructor).WithMany(i => i.StudentCards).OnDelete(DeleteBehavior.Restrict);
                sc.HasOne(sc => sc.Student).WithMany(s => s.StudentCards).OnDelete(DeleteBehavior.Restrict);
                sc.Property(sc => sc.IsDeleted).HasDefaultValue(false);
            });

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}