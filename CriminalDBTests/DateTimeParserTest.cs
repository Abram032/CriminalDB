using System;
using Xunit;

namespace CriminalDBTests
{
    public class DateTimeParserTest
    {
        [Theory]
        [InlineData("2018-05-14")] //Fails
        [InlineData("2018-14-05")]
        [InlineData("14-05-2018")]
        [InlineData("14-05-2018 14")] //Fails
        [InlineData("14-05-2018 14:48")]
        [InlineData("14-05-2018 14:48:25")] 
        public void TestDateTimes(string date)
        {
            Assert.True(TryParseDateTime(date));
        }

        private bool TryParseDateTime(string dateTime)
        {
            return DateTime.TryParse(dateTime, out DateTime result);          
        }
    }
}