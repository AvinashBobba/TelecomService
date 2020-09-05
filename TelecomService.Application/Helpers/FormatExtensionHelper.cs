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
            format = format.Replace(replaceCountryCode, "");
            if (format.StartsWith("0"))
            {
                format = format.Substring(1);
            }

            var regexFormat = format;
            regexFormat = regexFormat.Replace(" ", "");
            string stratsWith = GetStartsWithFormat(regexFormat);
            string regexEntryPattern = $"{regexFormat.Replace("#", @"\d")}";

            phoneNoFormats.Add(new CountryRegex()
            {
                Country = replaceCountryCode,
                RegexFormat = regexEntryPattern,
                StartsWithFormat = stratsWith,
                PhoneNoFormat = regexFormat
            }
                                    , GetOutputFormat(format));
        }

        private static string GetStartsWithFormat(ReadOnlySpan<char> input)
        {
            Span<char> output = input.ToArray();
            for (int i = input.Length - 1; i > -1; i--)
            {
                char val = input[i];
                if (val != '#')
                {
                    output = output.Slice(0, i + 1);
                    break;
                }
            }

            return output.ToString().Replace("#", @"\d");
        }

        private static string GetOutputFormat(ReadOnlySpan<char> input)
        {
            Span<char> output = input.ToArray();
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

            return output.ToString();
        }
    }
}
