using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelecomService.Api.Factory;
using TelecomService.Api.Helpers;
using TelecomService.Domain.Request;
using TelecomService.Domain.Response;

namespace TelecomService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneNumberFormatController : ControllerBase
    {
        private readonly PhoneNumberManagerFactory phoneNumberManagerFactory;

        public PhoneNumberFormatController(PhoneNumberManagerFactory phoneNumberManagerFactory)
        {
            this.phoneNumberManagerFactory = phoneNumberManagerFactory;
        }

        /// <summary>
        /// Returns the Phone Number in user readbale format 
        /// </summary>
        /// <param name="phoneNumberFormatRequest"></param>
        [HttpPost(ApiRoutes.PhoneNumberFormat.FormatPhoneNumber)]
        [ProducesResponseType(typeof(PhoneNumberFormatResponse), statusCode: 201)]
        [ProducesResponseType(typeof(ErrorMessageResponse), statusCode: 400)]
        public async Task<IActionResult> FormatPhoneNumber([FromBody] PhoneNumberFormatRequest phoneNumberFormatRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorMessageResponse { Message = "Phone Number cannot be empty" });
            }
            var manager = this.phoneNumberManagerFactory
                .GetPhoneFormatManager(phoneNumber: phoneNumberFormatRequest.PhoneNumber);
            var formattedData = manager.GetFormattedPhoneNo(phoneNumber: phoneNumberFormatRequest.PhoneNumber);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = $"{baseUrl}/{ApiRoutes.PhoneNumberFormat.FormatPhoneNumber}";
            return await Task.FromResult(Created(uri: locationUrl, value: formattedData));
        }
    }
}
