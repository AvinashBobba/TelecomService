using System.Collections.Generic;

namespace TelecomService.Domain.Options
{
    public class FormattingRulesOptions
    {
        public List<FormattingRules> FormattingRules { get; set; }
    }

    public class FormattingRules
    {
        public string CountryCode { get; set; }

        public List<string> Formats { get; set; }
    }
}
