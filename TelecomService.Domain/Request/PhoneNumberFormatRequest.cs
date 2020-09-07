using System.ComponentModel.DataAnnotations;
using TelecomService.Domain.CustomAttribute;

namespace TelecomService.Domain.Request
{
    public class PhoneNumberFormatRequest
    {
        [Required(ErrorMessage ="Phone Number is Required")]
        [Display(Name = "Number to Format")]
        [ValidatePhoneNumber(ErrorMessage = "Yet no numbers beginning with 04 or 06 in UK")]
        public string PhoneNumber { get; set; }

    }
}
