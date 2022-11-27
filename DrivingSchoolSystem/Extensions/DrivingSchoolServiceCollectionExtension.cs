using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Services;

namespace DrivingSchoolSystem.Extensions
{
    public static class DrivingSchoolServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDrivingSchoolService, DrivingSchoolService>();

            return services;
        }
    }
}
