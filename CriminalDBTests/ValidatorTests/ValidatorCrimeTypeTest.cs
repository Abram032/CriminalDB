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
    public class ValidatorCrimeTypeTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static ICrimeSeeder crimeSeeder = new CrimeSeeder(rng);

        [Theory]
        [InlineData("a")]
        [InlineData("A")]
        [InlineData("Type")]
        [InlineData("CrimeCrimeCrimeCrimeCrimeCrimeCrimeCrimeCrimeCrime")]
        public void ValidType(string input)
        {
            var crime = crimeSeeder.GetRandomCrimeSeed();
            crime.CrimeCriminals.Add(new CrimeCriminal());
            crime.Type = input;
            Assert.True(validator.Validate(crime));
        }

        [Theory]
        [InlineData("")]
        [InlineData("CrimeCrimeCrimeCrimeCrimeCrimeCrimeCrimeCrimeCrimeT")]
        public void InvalidType(string input)
        {
            var crime = crimeSeeder.GetRandomCrimeSeed();
            crime.CrimeCriminals.Add(new CrimeCriminal());
            crime.Type = input;
            Assert.False(validator.Validate(crime));
        }
    }
}