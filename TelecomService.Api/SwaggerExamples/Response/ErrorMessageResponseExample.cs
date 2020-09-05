using Swashbuckle.AspNetCore.Filters;
using TelecomService.Domain.Response;

namespace TelecomService.Api.SwaggerExamples.Response
{
    public class ErrorMessageResponseExample : IExamplesProvider<ErrorMessageResponse>
    {
        public ErrorMessageResponse GetExamples()
        {
            return new ErrorMessageResponse
            {
                Message = "Application Error"
            };
        }
    }
}
