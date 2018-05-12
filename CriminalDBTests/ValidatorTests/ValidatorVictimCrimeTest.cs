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
    public class ValidatorVictimCrimeTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static IPersonSeeder personSeeder = new PersonSeeder(rng);

        [Fact]
        public void ValidCrimes()
        {
            var victim = personSeeder.GetRandomPersonSeed<Victim>();
            victim.Crimes.Add(new CrimeVictim());
            Assert.True(validator.Validate(victim));
        }

        [Fact]
        public void InvalidCrimes()
        {
            var victim = personSeeder.GetRandomPersonSeed<Victim>();        
            Assert.False(validator.Validate(victim));
        }
    }
}