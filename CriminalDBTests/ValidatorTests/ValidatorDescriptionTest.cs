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
    public class ValidatorDescriptionTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static IPersonSeeder personSeeder = new PersonSeeder(rng);

        [Theory]
        [InlineData("a")]
        [InlineData("A")]
        [InlineData("Sample description.")]
        [InlineData("sample description.")]
        [InlineData(@"descriptiondescriptiondescriptiondescriptiondescriptiondescription
        descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription
        descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription
        descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription
        descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription
        descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondesc")]
        public void ValidDescription(string input)
        {
            var len = input.Length;
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.Description = input;
            Assert.True(validator.Validate(criminal));
        }

        [Theory]
        [InlineData("")]
        [InlineData(@"descriptiondescriptiondescriptiondescriptiondescriptiondescription
        descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription
        descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription
        descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription
        descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescription
        descriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescriptiondescr")]
        public void InvalidDescription(string input)
        {
            var len = input.Length;
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.Description = input;
            Assert.False(validator.Validate(criminal));
        }
    }
}