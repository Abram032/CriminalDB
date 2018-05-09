using CriminalDB.Core.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace CriminalDBTests
{
    public class UnitTest1
    {
        Person person = new Victim();

        [Fact]
        public void ValidPerson()
        {
            #region stuff
            person.FirstName = "Test";
            person.LastName = "Cos";
            person.Gender = Enums.Gender.Male;
            person.Nationality = "Uganda";
            person.DateOfBirth = new DateTime();
            person.Height = 1.91f;
            person.Weight = 89.4f;
            person.Photo = "Zulul";
            person.Address = "4House";
            #endregion
            Assert.True(Validate(person).Count > 0);
        }

        [Fact]
        public void InvalidPerson()
        {
            #region stuff
            person.FirstName = "t2est";person.LastName = "Cos";
            person.Gender = Enums.Gender.Male;
            person.Nationality = "Uganda";
            person.DateOfBirth = new DateTime();
            person.Height = 1.91f;
            person.Weight = 89.4f;
            person.Photo = "Zulul";
            person.Address = "4House";
            #endregion
            Assert.True(Validate(person).Count > 0);
        }

        private IList<ValidationResult> Validate(Person model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }
    }
}
