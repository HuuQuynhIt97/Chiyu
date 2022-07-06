using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chiyu.Installer
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
