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
               .Where(x => x.CountryCode == COUNTRY_CODE)
               .Select(x => x.Formats)
               .FirstOrDefault();

            foreach (var formatting in formattingRules)
            {
                FormatExtensionHelper.PopulateFormats(_phoneNoFormats, formatting, COUNTRY_CODE);
            }
        }

        public PhoneNumberFormatResponse GetFormattedPhoneNo(string strVal)
        {
            var response = new PhoneNumberFormatResponse();
            response.FormattedPhoneNumber = strVal.Replace(COUNTRY_CODE, "");
            var matchPattern = _phoneNoFormats.Where(kv => kv.Key.Country == COUNTRY_CODE
                                                                    && kv.Key.PhoneNoFormat.Length == response.FormattedPhoneNumber.Length
                                                                    && Regex.Match(strVal, kv.Key.RegexFormat).Success
                                                                    && Regex.Match(strVal, kv.Key.StartsWithFormat).Success
                                                            )
                                                        .OrderByDescending(kv => kv.Key.StartsWithFormat.Length)
                                                        .FirstOrDefault()
                                                    ;
            if (matchPattern.Value != null)
            {
                var phoneNo = strVal.Replace(matchPattern.Key.Country, "");
                long.TryParse(phoneNo, out long value);
                response.FormattedPhoneNumber = value.ToString($"0{matchPattern.Value}");
            }

            return response;
        }
    }
}
