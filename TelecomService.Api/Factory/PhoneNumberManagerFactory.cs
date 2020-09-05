using Microsoft.Extensions.DependencyInjection;
using System;
using TelecomService.Application.Manager;

namespace TelecomService.Api.Factory
{
    public class PhoneNumberManagerFactory
    {
        private readonly IServiceProvider serviceProvider;

        public PhoneNumberManagerFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IPhoneNumberFormatManager GetPhoneFormatManager(string phoneNumber)
        {
            IPhoneNumberFormatManager phoneNumberFormatManager = null;
            if (phoneNumber.StartsWith("+44"))
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
