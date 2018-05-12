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
    public class ValidatorCrimeVictimTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static ICrimeSeeder crimeSeeder = new CrimeSeeder(rng);

        [Fact]
        public void ValidCrimeVictim_1()
        {
            var crime = crimeSeeder.GetRandomCrimeSeed();
            crime.CrimeCriminals.Add(new CrimeCriminal());
            crime.CrimeVictims.Add(new CrimeVictim());
            Assert.True(validator.Validate(crime));
        }

        [Fact]
        public void ValidCrimeVictim_2()
        {
            var crime = crimeSeeder.GetRandomCrimeSeed();
            crime.CrimeCriminals.Add(new CrimeCriminal());
            Assert.True(validator.Validate(crime));
        }
    }
}