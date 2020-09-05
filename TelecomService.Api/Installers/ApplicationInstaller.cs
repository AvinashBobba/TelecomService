using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelecomService.Api.Factory;
using TelecomService.Application.Manager;
using TelecomService.Domain.Options;

namespace TelecomService.Api.Installers
{
    public class ApplicationInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var formattingRulesOptions = new FormattingRulesOptions();

            configuration
                .GetSection(key: nameof(FormattingRulesOptions))
                .Bind(formattingRulesOptions);
            
            serviceCollection.AddSingleton(implementationInstance: formattingRulesOptions);
            serviceCollection.AddSingleton<UKPhoneNumberManager, UKPhoneNumberManager>();
            serviceCollection.AddSingleton<DefaultPhoneNumberManager, DefaultPhoneNumberManager>();
            serviceCollection.AddSingleton<PhoneNumberManagerFactory, PhoneNumberManagerFactory>();
        }
    }
}
