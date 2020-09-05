using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TelecomService.Api.Installers;

namespace TelecomService.Api.Extensions
{
    public static class InstallerExtension
    {
        public static void InstallServicesInAssembly(this IServiceCollection serviceCollection, 
            IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
                        .Where(x => typeof(IInstaller)
                        .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                        .Select(selector: Activator.CreateInstance)
                        .Cast<IInstaller>()
                        .ToList();

            foreach (var installer in installers)
            {
                installer.InstallServices(serviceCollection: serviceCollection,
                    configuration: configuration);
            }
        }
    }
}
