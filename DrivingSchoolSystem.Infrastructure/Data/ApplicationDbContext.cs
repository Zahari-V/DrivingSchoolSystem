using DrivingSchoolSystem.Infrastructure.Data.Configuration;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(u =>
            {
                u.Property(u => u.UserName).HasMaxLength(25);
                u.Property(u => u.NormalizedUserName).HasMaxLength(25);
                u.Property(u => u.Email).HasMaxLength(25).IsRequired();
                u.Property(u => u.NormalizedEmail).HasMaxLength(25);
                u.Property(u => u.PhoneNumber).HasMaxLength(15).IsRequired();
                u.Property(u => u.IsRegistered).HasDefaultValue(false);
            });

            builder.Entity<UserRole>(ur =>
            {
                ur.HasOne(ur => ur.User).WithMany(u => u.UsersRoles).HasForeignKey(ur => ur.UserId);
                ur.HasOne(ur => ur.Role).WithMany(u => u.UsersRoles).HasForeignKey(ur => ur.RoleId);
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
            });

            builder.Entity<StudentCard>(sc =>
            {
                sc.Property(sc => sc.DrivedHours).HasDefaultValue(0);
                sc.HasOne(sc => sc.Instructor).WithMany(i => i.StudentCards).OnDelete(DeleteBehavior.Restrict);
                sc.HasOne(sc => sc.Student).WithMany(s => s.StudentCards).OnDelete(DeleteBehavior.Restrict);
            });

            builder.ApplyConfiguration(new DrivingSchoolConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}