using System;
using CriminalDB.Core.DataModels;
using CriminalDB.Core.DataSeeder;
using CriminalDB.Core.EntityValidator;
using CriminalDB.Core.Utilities;
using CriminalDB.Persistence.DataSeeder;
using CriminalDB.Persistence.EntityValidator;
using CriminalDB.Persistence.Utilities;
using Xunit;

namespace CriminalDBTests.ValidatorTests
{
    public class ValidatorDateTest
    {
        IEntityValidator validator = new EntityValidator();

        [Theory]
        [InlineData("17-04-1995")]
        [InlineData("17-04-1995 11:31")]
        [InlineData("17-04-1995 11:31:17")]
        public void ValidDate_1(string t1)
        {
            DateTime _t1 = DateTime.Parse(t1); 
            Assert.True(validator.ValidateDates(_t1));
        }

        [Theory]
        [InlineData("17-04-1995", "12-11-2005")]
        [InlineData("17-04-1995", "12-11-2005 14:47")]
        [InlineData("17-04-1995 11:31", "12-11-2005 14:47")]
        [InlineData("17-04-1995 11:31", "12-11-2005")]
        public void ValidDate_2(string t1, string t2)
        {
            DateTime _t1 = DateTime.Parse(t1);
            DateTime _t2 = DateTime.Parse(t2); 
            Assert.True(validator.ValidateDates(_t1, _t2));
        }

        [Fact]
        public void InvalidDate_0()
        {
            Assert.False(validator.ValidateDates(DateTime.Now.AddSeconds(1)));
        }
        
        [Theory]
        [InlineData("17-04-2020")]
        [InlineData("17-04-2020 11:31")]
        [InlineData("17-04-2020 11:31:17")]
        public void InvalidDate_1(string t1)
        {
            DateTime _t1 = DateTime.Parse(t1); 
            Assert.False(validator.ValidateDates(_t1));
        }

        [Theory]
        [InlineData("17-04-2006", "12-11-2005")]
        [InlineData("12-11-2005", "12-11-2005")]
        [InlineData("13-11-2005", "12-11-2005")]
        [InlineData("12-12-2005", "12-11-2005")]
        [InlineData("12-11-2005 11:11", "12-11-2005 10:11")]
        [InlineData("12-11-2005 10:11", "12-11-2005 10:11")]
        [InlineData("12-11-2005 10:11", "12-11-2005 10:10")]
        [InlineData("12-11-2005 10:10:11", "12-11-2005 10:10:10")]
        public void InvalidDate_2(string t1, string t2)
        {
            DateTime _t1 = DateTime.Parse(t1);
            DateTime _t2 = DateTime.Parse(t2);
            Assert.False(validator.ValidateDates(_t1, _t2));
        }
    }
}