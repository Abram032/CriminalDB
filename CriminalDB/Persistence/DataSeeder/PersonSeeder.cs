using CriminalDB.Core.DataModels;
using CriminalDB.Core.DataSeeder;
using CriminalDB.Core.Utilities;
using CriminalDB.Persistence.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.DataSeeder
{
    public class PersonSeeder : IPersonSeeder
    {
        private IRandomGenerator _randomGenerator;
        public PersonSeeder(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }
        private List<string> maleNames = new List<string>
        { "Jack", "Daniel", "John", "Jackson", "Matthew", "Adam", "Arthur", "Logan", "Bradyn", "George", "Cooper", "Terry", "Carl" };

        private List<string> femaleNames = new List<string>
        { "Samantha", "Mia", "Lydia", "Emilee", "Kelly", "Quinn", "Alexia", "Dahlia", "Christine", "Danielle", "Naomi", "Farrah", "Serena" };

        private List<string> lastNames = new List<string>
        { "West", "Martin", "Salazar", "Joseph", "Delacruz", "Woods", "Hart", "Morris", "Medina", "Rowland", "Reynolds", "Owen", "Hamilton" };

        private List<string> nationalites = new List<string>
        { "Poland", "UK", "USA", "Uganda", "Russia", "Germany", "France", "Czech", "Slovakia", "Ireland", "Netherlands", "Ukraine", "RPA" };

        private List<string> addresses = new List<string>
        { "First", "Central", "School", "North", "Columbia", "Rose", "Summer", "Winter", "West", "Overlook", "Cambrige", "Grand", "Locust" };

        private List<string> streets = new List<string>
        { "Lane", "Avenue", "Street", "Road", "Drive", "Circle", "Court", "Run", "Place" };

        private List<string> genders = new List<string>
        { "Male", "Female" };

        public TEntity GetRandomPersonSeed<TEntity>() where TEntity : Person, new()
        {
            TEntity person = new TEntity();
            string gender = _randomGenerator.GetRandomElement(genders);
            if(gender == "Female")
                person.FirstName = _randomGenerator.GetRandomElement(femaleNames);
            else
                person.FirstName = _randomGenerator.GetRandomElement(maleNames);
            person.LastName = _randomGenerator.GetRandomElement(lastNames);
            person.Nationality = _randomGenerator.GetRandomElement(nationalites);
            person.Address = _randomGenerator.GetRandomElement(addresses) 
                + " " + _randomGenerator.GetRandomElement(streets);
            person.Gender = gender;
            person.Height = _randomGenerator.GetRandomInt(150, 230);
            person.Weight = _randomGenerator.GetRandomInt(50, 130);
            person.DateOfBirth = _randomGenerator.GetRandomDate();
            person.Photo = "URL";
            var criminal = person as Criminal;
            if(criminal != null)
                criminal.Description = "Test description.";
            return person;
        }
    }
}
