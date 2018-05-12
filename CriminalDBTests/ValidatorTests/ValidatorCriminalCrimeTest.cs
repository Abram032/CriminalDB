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
    public class ValidatorCriminalCrimeTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static IPersonSeeder personSeeder = new PersonSeeder(rng);

        [Fact]
        public void ValidCrimes()
        {
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            Assert.True(validator.Validate(criminal));
        }

        [Fact]
        public void InvalidCrimes()
        {
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            Assert.False(validator.Validate(criminal));
        }
    }
}