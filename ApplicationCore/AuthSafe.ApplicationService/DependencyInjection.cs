using AuthSafe.ApplicationService.Commons.Mappers.Auth;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AuthSafe.ApplicationService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSigCoraApplicationService(this IServiceCollection services)
        {

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<IAuthMapper, AuthMapper>();

            return services;
        }
    }
}
