using CriminalDB.Core.DataModels;
using System;
using System.Collections.Generic;
using static CriminalDB.Persistence.Utilities.RandomGenerator;
using System.Text;

namespace CriminalDB.Persistence.DataSeeder
{
    public class CrimeSeeder
    {
        private List<string> crimeTypes = new List<string>
        { "Arson", "Theft", "Burglary", "Fraud", "Piracy", "Cyber Crime", "Murder", "Robbery", "Terrorism" };

        private List<string> locations = new List<string>
        { "Warsaw", "London", "Berlin", "Paris", "Moscow", "Dublin", "Amsterdam", "Rome", "Prague" };

        public Crime GetRandomCrimeSeed()
        {
            Crime crime = new Crime
            {
                Type = GetValue(crimeTypes),
                Location = GetValue(locations),
                Time = DateTime.Now,
                Description = "Radnom description."
            };
            return crime;
        }
    }
}
