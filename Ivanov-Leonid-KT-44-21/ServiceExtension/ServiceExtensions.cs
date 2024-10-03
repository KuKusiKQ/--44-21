using Ivanov_Leonid_KT_44_21.Interfaces;

namespace Ivanov_Leonid_KT_44_21.ServiceExtension
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}