using System;
using Xunit;

namespace CriminalDBTests.OtherTests
{
    public class DateTimeParserTest
    {
        [Theory]
        [InlineData("14-05-2018")]
        [InlineData("14-05-2018 14:48")]
        [InlineData("14-05-2018 14:48:25")] 
        public void ValidDateTime(string date)
        {
            Assert.True(TryParseDateTime(date));
        }

        [Theory]
        [InlineData("14-05-2018 14")]
        [InlineData("14-25-2018")]
        [InlineData("45-25-2018")]
        public void InvalidDateTime(string date)
        {
            Assert.False(TryParseDateTime(date));
        }

        private bool TryParseDateTime(string dateTime)
        {
            return DateTime.TryParse(dateTime, out DateTime result);          
        }
    }
}