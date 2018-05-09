using CriminalDB.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using static CriminalDB.Core.DataModels.Enums;
using static CriminalDB.Persistence.Utilities.RandomGenerator;

namespace CriminalDB.Persistence.DataSeeder
{
    public class PersonSeeder
    {
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

        public TEntity GetRandomPersonSeed<TEntity>() where TEntity : Person, new()
        {
            TEntity person = new TEntity();
            int gender = GetRandomInt(0,2);
            if(gender == 0)
                person.FirstName = GetValue(femaleNames);
            else
                person.FirstName = GetValue(maleNames);
            person.LastName = GetValue(lastNames);
            person.Nationality = GetValue(nationalites);
            person.Address = GetValue(addresses) + " " + GetValue(streets);
            person.Gender = (Gender)gender;
            person.Height = GetRandomInt(150, 230);
            person.Weight = GetRandomInt(50, 130);
            person.DateOfBirth = DateTime.Now;
            person.Photo = "URL";
            return person;
        }
    }
}
