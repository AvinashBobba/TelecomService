using System.Threading.Tasks;
using TelecomService.Domain.Response;

namespace TelecomService.Application.Manager
{
    public interface IPhoneNumberFormatManager
    {
        public  Task<PhoneNumberFormatResponse> GetFormattedPhoneNo(string phoneNumber);
    }
}
