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
    public class ValidatorCrimeCriminalTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static ICrimeSeeder crimeSeeder = new CrimeSeeder(rng);

        [Fact]
        public void ValidCrimeCriminal()
        {
            var crime = crimeSeeder.GetRandomCrimeSeed();
            crime.CrimeCriminals.Add(new CrimeCriminal());
            Assert.True(validator.Validate(crime));
        }

        [Fact]
        public void InvalidCrimeCriminal()
        {
            var crime = crimeSeeder.GetRandomCrimeSeed();
            Assert.False(validator.Validate(crime));
        }
    }
}