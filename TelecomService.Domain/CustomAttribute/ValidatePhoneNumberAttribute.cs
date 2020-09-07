using System;
using System.ComponentModel.DataAnnotations;

namespace TelecomService.Domain.CustomAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class ValidatePhoneNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputValue = value as string;
            var isValid = true;

            if ((inputValue.StartsWith("+444") || inputValue.StartsWith("+446")))
            {
                isValid = false;
            }

            return isValid;
        }

    }
}
