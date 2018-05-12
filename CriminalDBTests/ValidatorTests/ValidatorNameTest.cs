using CriminalDB.Core.DataModels;
using CriminalDB.Core.DataSeeder;
using CriminalDB.Persistence.DataSeeder;
using CriminalDB.Persistence.EntityValidator;
using CriminalDB.Core.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;
using CriminalDB.Persistence.Utilities;
using CriminalDB.Core.EntityValidator;

namespace CriminalDBTests.ValidatorTests
{
    public class ValidatorNameTest
    {
        IEntityValidator validator = new EntityValidator();
        static IRandomGenerator rng = new RandomGenerator();
        static IPersonSeeder personSeeder = new PersonSeeder(rng);

        [Theory]
        [InlineData("Bob")]
        [InlineData("BobMartin")]
        [InlineData("BobbobboboBobbobboboBobbobboboBobbobboboBobbobbobo")]
        public void ValidName(string input)
        {
            Criminal criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.FirstName = input;
            Assert.True(validator.Validate(criminal));
        }

        [Theory]
        [InlineData("")]
        [InlineData("2484")]
        [InlineData("B434833ob")]
        [InlineData("BobbobboboBobbobboboBobbobboboBobbobboboBobbobbobob")]
        [InlineData("Bob Martin")]
        [InlineData("Bob ")]
        [InlineData(" Bob")]
        [InlineData("Bob-Martin")]
        public void InvalidName(string input)
        {
            Criminal criminal = personSeeder.GetRandomPersonSeed<Criminal>();
            criminal.Crimes.Add(new CrimeCriminal());
            criminal.FirstName = input;
            Assert.False(validator.Validate(criminal));
        }
    }
}
