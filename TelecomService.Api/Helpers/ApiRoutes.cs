namespace TelecomService.Api.Helpers
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class PhoneNumberFormat
        {
            public const string FormatPhoneNumber = Base + "/formatPhoneNumber";
        }
    }
}
