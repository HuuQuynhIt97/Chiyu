using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Chiyu.Services;

namespace Chiyu.Installer
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMailingService, MailingService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IOCService, OCService>();

        }
    }
}
