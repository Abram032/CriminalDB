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
    public class ValidatorGenderTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static IPersonSeeder personSeeder = new PersonSeeder(rng);

        [Theory]
        [InlineData("Female")]
        [InlineData("female")]
        [InlineData("Male")]
        [InlineData("male")]
        public void ValidGender(string input)
        {
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.Gender = input;
            Assert.True(validator.Validate(criminal));
        }

        [Theory]
        [InlineData("")]
        [InlineData("f")]
        [InlineData("F")]
        [InlineData("m")]
        [InlineData("M")]
        [InlineData("M4le")]
        [InlineData("F3male")]
        [InlineData("m4le")]
        [InlineData("f3male")]
        public void InvalidGender(string input)
        {
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.Gender = input;
            Assert.False(validator.Validate(criminal));
        }
    }
}