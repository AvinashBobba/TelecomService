using TelecomService.Domain.Response;

namespace TelecomService.Application.Manager
{
    public interface IPhoneNumberFormatManager
    {
        public PhoneNumberFormatResponse GetFormattedPhoneNo(string phoneNumber);
    }
}
