using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TelecomService.Api.Factory;
using TelecomService.Api.Filters;
using TelecomService.Api.Helpers;
using TelecomService.Domain.Request;
using TelecomService.Domain.Response;

namespace TelecomService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiKeyAuth]
    public class PhoneNumberFormatController : ControllerBase
    {
        private readonly ILogger<PhoneNumberFormatController> _logger;
        private readonly PhoneNumberManagerFactory _phoneNumberManagerFactory;

        public PhoneNumberFormatController(ILogger<PhoneNumberFormatController> logger, 
            PhoneNumberManagerFactory phoneNumberManagerFactory)
        {
            _logger = logger;
            _phoneNumberManagerFactory = phoneNumberManagerFactory;
        }



        /// <summary>
        /// Returns the Phone Number in user readbale format 
        /// </summary>
        /// <param name="phoneNumberFormatRequest"></param>
        [HttpPost(template: ApiRoutes.PhoneNumberFormat.FormatPhoneNumber)]
        [ProducesResponseType(type: typeof(PhoneNumberFormatResponse), statusCode: 201)]
        [ProducesResponseType(type: typeof(ErrorMessageResponse), statusCode: 400)]
        public async Task<IActionResult> FormatPhoneNumber([FromBody] PhoneNumberFormatRequest phoneNumberFormatRequest)
        {
            _logger.LogInformation(message: "Calling FormatPhoneNumber Method");

            if (!ModelState.IsValid)
            {
                return BadRequest(error: new ErrorMessageResponse { Message = "Phone Number cannot be empty" });
            }

            var manager = _phoneNumberManagerFactory
                .GetPhoneFormatManager(phoneNumber: phoneNumberFormatRequest.PhoneNumber);

            var formattedData = await manager
                .GetFormattedPhoneNo(phoneNumber: phoneNumberFormatRequest.PhoneNumber);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = $"{baseUrl}/{ApiRoutes.PhoneNumberFormat.FormatPhoneNumber}";

            _logger.LogInformation(message: "Ended FormatPhoneNumber Method");

            return Created(uri: locationUrl, value: formattedData); ;
        }
    }
}
