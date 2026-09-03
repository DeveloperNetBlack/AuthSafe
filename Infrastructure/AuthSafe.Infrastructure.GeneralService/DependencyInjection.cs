using AuthSafe.DomainService.IServices;
using AuthSafe.Infrastructure.GeneralService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AuthSafe.Infrastructure.GeneralService
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSigCoraInfrastructureGeneralService(this IServiceCollection services)
        {

            services.AddSingleton<ICurrentSessionService, CurrentSessionService>();
            services.AddScoped<IGenerateTokenService, GenerateTokenService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IJsonSerializerService, JsonSerializerService>();
            //services.AddScoped<IFileStorageService, LocalFileStorageServuce>();

            return services;
        }
    }
}
