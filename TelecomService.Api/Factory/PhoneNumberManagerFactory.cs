using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using TelecomService.Application.Manager;

namespace TelecomService.Api.Factory
{
    public class PhoneNumberManagerFactory
    {
        private const string UK_COUNTRY_CODE = "+44";
        private readonly IServiceProvider _serviceProvider;
        private ILogger<PhoneNumberManagerFactory> _logger;
        public PhoneNumberManagerFactory(IServiceProvider serviceProvider,
            ILogger<PhoneNumberManagerFactory> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public IPhoneNumberFormatManager GetPhoneFormatManager(string phoneNumber)
        {
            IPhoneNumberFormatManager phoneNumberFormatManager;
            if (phoneNumber.StartsWith(value: UK_COUNTRY_CODE))
            {
                phoneNumberFormatManager = _serviceProvider.GetRequiredService<UKPhoneNumberManager>();
            }
            else
            {
                phoneNumberFormatManager = _serviceProvider.GetRequiredService<DefaultPhoneNumberManager>();
            }
            _logger.LogInformation($"PhoneNumber Format type {phoneNumberFormatManager?.GetType().Name}");
            return phoneNumberFormatManager;
        }
    }
}
