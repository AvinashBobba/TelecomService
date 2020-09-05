using Swashbuckle.AspNetCore.Filters;
using TelecomService.Domain.Response;

namespace TelecomService.Api.SwaggerExamples.Response
{
    public class PhoneNumberFormatResponseExample : IExamplesProvider<PhoneNumberFormatResponse>
    {
        public PhoneNumberFormatResponse GetExamples()
        {
            return new PhoneNumberFormatResponse
            {
                FormattedPhoneNumber = "0113 496 0018"
            };
        }
    }
}
