using Microsoft.Extensions.DependencyInjection;
using System;
using TelecomService.Application.Manager;

namespace TelecomService.Api.Factory
{
    public class PhoneNumberManagerFactory
    {
        private const string UK_COUNTRY_CODE = "+44";
        private readonly IServiceProvider serviceProvider;

        public PhoneNumberManagerFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IPhoneNumberFormatManager GetPhoneFormatManager(string phoneNumber)
        {
            IPhoneNumberFormatManager phoneNumberFormatManager;
            if (phoneNumber.StartsWith(value: UK_COUNTRY_CODE))
            {
                phoneNumberFormatManager = serviceProvider.GetRequiredService<UKPhoneNumberManager>();
            }
            else
            {
                phoneNumberFormatManager = serviceProvider.GetRequiredService<DefaultPhoneNumberManager>();
            }
            return phoneNumberFormatManager;
        }
    }
}
