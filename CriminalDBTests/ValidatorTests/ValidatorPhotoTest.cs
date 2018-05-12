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
    public class ValidatorPhotoTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static IPersonSeeder personSeeder = new PersonSeeder(rng);

        [Theory]
        [InlineData("u")]
        [InlineData("U")]
        [InlineData("URL")]
        [InlineData(@"uRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinkurluR
        LlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinku
        rluRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLl
        inkurluRLlinkurluRLlinkurluRLlinkurluRL")]
        public void ValidPhoto(string input)
        {
            var len = input.Length;
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.Photo = input;
            Assert.True(validator.Validate(criminal));
        }

        [Theory]
        [InlineData("")]
        [InlineData(@"uRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinkurluR
        LlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinku
        rluRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLlinkurluRLl
        inkurluRLlinkurluRLlinkurluRLlinkurluRLe")]
        public void InvalidPhoto(string input)
        {
            var criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.Photo = input;
            Assert.False(validator.Validate(criminal));
        }
    }
}