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
    public class ValidatorAddressTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static IPersonSeeder personSeeder = new PersonSeeder(rng);

        [Theory]
        [InlineData("F")]
        [InlineData("First")]
        [InlineData("First St.")]
        [InlineData("first St. 29")]
        [InlineData("First St. - 29")]
        [InlineData("FirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirst")]
        public void ValidAddress(string input)
        {
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.Address = input;
            Assert.True(validator.Validate(criminal));
        }

        [Theory]
        [InlineData("")]
        [InlineData("firstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstFirstf")]
        public void InvalidAddress(string input)
        {
            var len = input.Length;
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.Address = input;
            Assert.False(validator.Validate(criminal));
        }   
    }
}