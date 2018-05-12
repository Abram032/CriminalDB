using System;
using Xunit;

namespace CriminalDBTests.OtherTests
{
    public class CaseSensitivityTest
    {
        [Theory]
        [InlineData("f")]
        [InlineData("F")]
        [InlineData("Female")]
        [InlineData("female")]
        public void TestStartWith(string input)
        {
            Assert.True(Check(input));
        }

        private bool Check(string input) => input.StartsWith("f", true, null);
    }
}