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
    public class ValidatorHeightTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static IPersonSeeder personSeeder = new PersonSeeder(rng);

        [Theory]
        [InlineData(1f)]
        [InlineData(10f)]
        [InlineData(100f)]
        [InlineData(167.3f)]
        [InlineData(167.32f)]
        [InlineData(167.324f)]
        [InlineData(300f)]
        public void ValidHeight(float value)
        {
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.Height = value;
            Assert.True(validator.Validate(criminal));
        }

        [Theory]
        [InlineData(0f)]
        [InlineData(301f)]
        [InlineData(-0.001f)]
        [InlineData(-1f)]
        [InlineData(-300f)]
        [InlineData(300.3f)]
        [InlineData(300.32f)]
        [InlineData(300.001f)]
        public void InvalidHeight(float value)
        {
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.Height = value;
            Assert.False(validator.Validate(criminal));
        }
    }
}