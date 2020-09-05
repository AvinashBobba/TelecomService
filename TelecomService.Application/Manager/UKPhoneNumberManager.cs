using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TelecomService.Application.Helpers;
using TelecomService.Domain;
using TelecomService.Domain.Options;
using TelecomService.Domain.Response;

namespace TelecomService.Application.Manager
{
    public class UKPhoneNumberManager : IPhoneNumberFormatManager
    {
        private const string COUNTRY_CODE = "+44";

        private readonly Dictionary<CountryRegex, string> _phoneNoFormats;

        private readonly FormattingRulesOptions _formattingRulesOptions;

        public UKPhoneNumberManager(FormattingRulesOptions formattingRulesOptions)
        {
            _phoneNoFormats = new Dictionary<CountryRegex, string>(); ;
            _formattingRulesOptions = formattingRulesOptions;
            LoadFormatters();

        }

        private void LoadFormatters()
        {
            var formattingRules = _formattingRulesOptions.FormattingRules
               .Where(predicate: x => x.CountryCode == COUNTRY_CODE)
               .Select(selector: x => x.Formats)
               .FirstOrDefault();

            foreach (var formatting in formattingRules)
            {
                FormatExtensionHelper.PopulateFormats(phoneNoFormats: _phoneNoFormats,
                    format: formatting,
                    replaceCountryCode: COUNTRY_CODE);
            }
        }

        public PhoneNumberFormatResponse GetFormattedPhoneNo(string phoneNumber)
        {
            var response = new PhoneNumberFormatResponse();
            
            response.FormattedPhoneNumber = phoneNumber
                .Replace(oldValue: COUNTRY_CODE,
                         newValue: "");

            var matchPattern = _phoneNoFormats.Where(predicate: kv => kv.Key.Country == COUNTRY_CODE
                                                                    && kv.Key.PhoneNoFormat.Length == response.FormattedPhoneNumber.Length
                                                                    && Regex.Match(input: phoneNumber, pattern: kv.Key.RegexFormat).Success
                                                                    && Regex.Match(input: phoneNumber, pattern: kv.Key.StartsWithFormat).Success
                                                            )
                                                        .OrderByDescending(keySelector: kv => kv.Key.StartsWithFormat.Length)
                                                        .FirstOrDefault();
            ;
            if (matchPattern.Value != null)
            {
                var phoneNo = phoneNumber.Replace(oldValue: matchPattern.Key.Country,newValue: "");
                long.TryParse(s: phoneNo,result: out long value);
                response.FormattedPhoneNumber = value.ToString(format: $"0{matchPattern.Value}");
            }

            return response;
        }
    }
}
