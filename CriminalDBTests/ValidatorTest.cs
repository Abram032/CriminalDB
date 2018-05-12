using CriminalDB.Core.DataModels;
using CriminalDB.Persistence.EntityValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace CriminalDBTests
{
    public class ValidatorTest
    {
        Person person = new Victim();
        EntityValidator validator = new EntityValidator();     

        [Fact]
        public void ValidPerson()
        {
            #region stuff
            person.FirstName = "Test";
            person.LastName = "Cos";
            person.Gender = "Male";
            person.Nationality = "Uganda";
            person.DateOfBirth = DateTime.Now;
            person.Height = 1.91f;
            person.Weight = 89.4f;
            person.Photo = "Zulul";
            person.Address = "4House";
            #endregion
            Assert.True(validator.Validate(person));
        }

        [Fact]
        public void InvalidPerson()
        {
            #region stuff
            person.FirstName = "t2est";
            person.LastName = "Cos";
            person.Gender = "Male";
            person.Nationality = "Uganda";
            person.DateOfBirth = DateTime.Now;
            person.Height = 1.91f;
            person.Weight = 89.4f;
            person.Photo = "Zulul";
            person.Address = "4House";
            #endregion
            Assert.False(validator.Validate(person));
        }
    }
}
