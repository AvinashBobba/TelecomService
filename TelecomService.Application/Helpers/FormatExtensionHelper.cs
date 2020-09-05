using System;
using System.Collections.Generic;
using TelecomService.Domain;

namespace TelecomService.Application.Helpers
{
    public static class FormatExtensionHelper
    {
        public static void PopulateFormats(this Dictionary<CountryRegex, string> phoneNoFormats,
            string format,
            string replaceCountryCode)
        {
            format = format
                .Replace(oldValue: replaceCountryCode,newValue: "");

            if (format.StartsWith(value: "0"))
            {
                format = format.Substring(startIndex: 1);
            }

            var regexFormat = format.Replace(oldValue: " ",newValue: "");

            string stratsWith = GetStartsWithFormat(input:regexFormat);
            
            string regexEntryPattern = $"{regexFormat.Replace(oldValue: "#",newValue: @"\d")}";

            phoneNoFormats.Add(
                key: new CountryRegex()
                                {
                                    Country = replaceCountryCode,
                                    RegexFormat = regexEntryPattern,
                                    StartsWithFormat = stratsWith,
                                    PhoneNoFormat = regexFormat
                                }, 
                value: GetOutputFormat(format));
        }

        private static string GetStartsWithFormat(ReadOnlySpan<char> input)
        {
            Span<char> output = input
                .ToArray();
            
            for (int i = input.Length - 1; i > -1; i--)
            {
                char val = input[i];
                if (val != '#')
                {
                    output = output
                        .Slice(start:0,length: i + 1);
                    break;
                }
            }

            return output
                .ToString()
                .Replace(oldValue: "#",newValue: @"\d");
        }

        private static string GetOutputFormat(ReadOnlySpan<char> input)
        {
            Span<char> output = input
                .ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                char val = input[i];
                if (val != '#' && val != ' ')
                {
                    output[i] = '#';
                }
                else
                {
                    output[i] = val;
                }
            }

            return output
                .ToString();
        }
    }
}
