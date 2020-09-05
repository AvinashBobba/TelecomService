using TelecomService.Domain.Response;

namespace TelecomService.Application.Manager
{
    public class DefaultPhoneNumberManager : IPhoneNumberFormatManager
    {
        public  PhoneNumberFormatResponse GetFormattedPhoneNo(string phoneNumber)
        {
            return new PhoneNumberFormatResponse { FormattedPhoneNumber = phoneNumber };
        }
    }
}
