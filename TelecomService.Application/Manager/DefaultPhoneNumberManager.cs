using System.Threading.Tasks;
using TelecomService.Domain.Response;

namespace TelecomService.Application.Manager
{
    public class DefaultPhoneNumberManager : IPhoneNumberFormatManager
    {
        public async  Task<PhoneNumberFormatResponse> GetFormattedPhoneNo(string phoneNumber)
        {
            return await Task.FromResult(new PhoneNumberFormatResponse { FormattedPhoneNumber = phoneNumber });
        }
    }
}
