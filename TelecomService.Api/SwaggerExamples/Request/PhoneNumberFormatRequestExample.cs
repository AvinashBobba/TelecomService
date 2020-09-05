using Swashbuckle.AspNetCore.Filters;
using TelecomService.Domain.Request;

namespace TelecomService.Api.SwaggerExamples.Request
{
    public class PhoneNumberFormatRequestExample : IExamplesProvider<PhoneNumberFormatRequest>
    {
        public PhoneNumberFormatRequest GetExamples()
        {
            return new PhoneNumberFormatRequest
            {
                PhoneNumber = "+441134960018"
            };
        }
    }
}
