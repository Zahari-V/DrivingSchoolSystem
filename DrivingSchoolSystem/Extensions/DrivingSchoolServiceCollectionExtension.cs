using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Services;
using DrivingSchoolSystem.Core.Contracts.Admin;
using DrivingSchoolSystem.Core.Services.Admin;

namespace DrivingSchoolSystem.Extensions
{
    public static class DrivingSchoolServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDrivingSchoolService, DrivingSchoolService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentCardService, StudentCardService>();

            return services;
        }
    }
}
