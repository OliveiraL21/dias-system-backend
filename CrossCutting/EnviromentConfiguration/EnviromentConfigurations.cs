using Domain.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;


namespace CrossCutting.EnviromentConfiguration
{
    public static class EnviromentConfigurations
    {
        public static void ConfigureDevelopmentEnvironment(IServiceCollection services, IConfiguration configuration)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var serverConfig = new ServerConfiguration();
            configuration.GetSection("ServerConfiguration").Bind(serverConfig);

            if (env == Environments.Development)
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    serverConfig.ServerUrl = "http://localhost:6001";
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    serverConfig.ServerUrl = "https://localhost:44336";
                }
            }

            services.AddSingleton(serverConfig);

            services.Configure<ServerConfiguration>(options =>
            {
                options.ServerUrl = serverConfig.ServerUrl;
            });
        }
    }
}
