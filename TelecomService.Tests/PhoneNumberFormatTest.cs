using Microsoft.Extensions.DependencyInjection;
using TelecomService.Application.Manager;
using Xunit;

namespace TelecomService.Tests
{
    public class PhoneNumberFormatTest : BaseTest
    {
        private readonly IPhoneNumberFormatManager _ukPhoneNumberFormatManager;
        private readonly IPhoneNumberFormatManager _defaultPhoneNumberFormatManager;

        public PhoneNumberFormatTest()
        {
            _ukPhoneNumberFormatManager = this.ServiceProvider.GetRequiredService<UKPhoneNumberManager>();
            _defaultPhoneNumberFormatManager = this.ServiceProvider.GetRequiredService<DefaultPhoneNumberManager>();
        }

        [Theory]
        [InlineData("+44123412345", "01234 12345")]
        [InlineData("+441234123456", "01234 123456")]
        public void UK_PhoneNumberFormat_StartWith_01_Test(string input, string expected)
        {
            var actual =  _ukPhoneNumberFormatManager.GetFormattedPhoneNo(phoneNumber: input).Result;

            Assert.Equal(expected: expected, actual: actual.FormattedPhoneNumber);
        }

        [Theory]
        [InlineData("+441122345678", "0112 234 5678")]
        public void UK_PhoneNumberFormat_StartWith_011_Test(string input, string expected)
        {
            var actual = _ukPhoneNumberFormatManager.GetFormattedPhoneNo(phoneNumber: input).Result;

            Assert.Equal(expected: expected, actual: actual.FormattedPhoneNumber);
        }

        [Theory]
        [InlineData("+441211231234", "0121 123 1234")]
        public void UK_PhoneNumberFormat_StartWith_01n1_Test(string input, string expected)
        {
            var actual = _ukPhoneNumberFormatManager.GetFormattedPhoneNo(phoneNumber: input).Result;

            Assert.Equal(expected: expected, actual: actual.FormattedPhoneNumber);
        }

        [Theory]
        [InlineData("+441339712345", "013397 12345")]
        [InlineData("+441339812345", "013398 12345")]
        [InlineData("+441387312345", "013873 12345")]
        [InlineData("+441524212345", "015242 12345")]
        [InlineData("+441539412345", "015394 12345")]
        [InlineData("+441539512345", "015395 12345")]
        [InlineData("+441539612345", "015396 12345")]
        [InlineData("+441697312345", "016973 12345")]
        [InlineData("+441697412345", "016974 12345")]
        [InlineData("+441697712345", "016977 12345")]
        [InlineData("+441768312345", "017683 12345")]
        [InlineData("+441768412345", "017684 12345")]
        [InlineData("+441768712345", "017687 12345")]
        [InlineData("+441946712345", "019467 12345")]
        [InlineData("+441975512345", "019755 12345")]
        [InlineData("+441975612345", "019756 12345")]
        public void UK_PhoneNumberFormat_5of5spacing_Format_Test(string input, string expected)
        {
            var actual = _ukPhoneNumberFormatManager.GetFormattedPhoneNo(phoneNumber: input).Result;

            Assert.Equal(expected: expected, actual: actual.FormattedPhoneNumber);
        }

        [Theory]
        [InlineData("+442112341234", "021 1234 1234")]
        public void UK_PhoneNumberFormat_StartWith_02_Test(string input, string expected)
        {
            var actual = _ukPhoneNumberFormatManager.GetFormattedPhoneNo(phoneNumber: input).Result;

            Assert.Equal(expected: expected, actual: actual.FormattedPhoneNumber);
        }

        [Theory]
        [InlineData("+443121231234", "0312 123 1234")]
        public void UK_PhoneNumberFormat_StartWith_03_Test(string input, string expected)
        {
            var actual = _ukPhoneNumberFormatManager.GetFormattedPhoneNo(phoneNumber: input).Result;

            Assert.Equal(expected: expected, actual: actual.FormattedPhoneNumber);
        }


        [Theory]
        [InlineData("+447123123456", "07123 123456")]
        [InlineData("+445123123456", "05123 123456")]
        public void UK_PhoneNumberFormat_StartsWith_07and05_Test(string input, string expected)
        {
            var actual = _ukPhoneNumberFormatManager.GetFormattedPhoneNo(phoneNumber: input).Result;

            Assert.Equal(expected: expected, actual: actual.FormattedPhoneNumber);
        }

        [Theory]
        [InlineData("+44800123456", "0800 123456")]
        public void UK_PhoneNumberFormat_StartsWith_0800_Test(string input, string expected)
        {
            var actual = _ukPhoneNumberFormatManager.GetFormattedPhoneNo(phoneNumber: input).Result;

            Assert.Equal(expected: expected, actual: actual.FormattedPhoneNumber);
        }


        [Theory]
        [InlineData("+448121231234", "0812 123 1234")]
        [InlineData("+449121231234", "0912 123 1234")]
        public void UK_PhoneNumberFormat_StartsWith_08nand09_Test(string input, string expected)
        {
            var actual = _ukPhoneNumberFormatManager.GetFormattedPhoneNo(phoneNumber: input).Result;

            Assert.Equal(expected: expected, actual: actual.FormattedPhoneNumber);
        }

        [Theory]
        [InlineData("+91123412345", "+91123412345")]
        [InlineData("+11234123456", "+11234123456")]
        public void Default_PhoneNumberFormat_StartsWithOtherThan_UK_Country_Code(string input, string expected)
        {
            var actual = _defaultPhoneNumberFormatManager.GetFormattedPhoneNo(phoneNumber: input).Result;

            Assert.Equal(expected: expected, actual: actual.FormattedPhoneNumber);
        }
    }
}
