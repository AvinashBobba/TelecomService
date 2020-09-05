using TelecomService.Domain.Response;

namespace TelecomService.Application.Manager
{
    public class DefaultPhoneNumberManager : IPhoneNumberFormatManager
    {
        public  PhoneNumberFormatResponse GetFormattedPhoneNo(string strVal)
        {
            return new PhoneNumberFormatResponse { FormattedPhoneNumber = strVal };
        }
    }
}
