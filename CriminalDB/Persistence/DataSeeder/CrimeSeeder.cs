using CriminalDB.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using CriminalDB.Persistence.Utilities;
using CriminalDB.Core.Utilities;
using CriminalDB.Core.DataSeeder;

namespace CriminalDB.Persistence.DataSeeder
{
    public class CrimeSeeder : ICrimeSeeder
    {
        private IRandomGenerator _randomGenerator;
        public CrimeSeeder(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }
        private List<string> crimeTypes = new List<string>
        { "Arson", "Theft", "Burglary", "Fraud", "Piracy", "Cyber Crime", "Murder", "Robbery", "Terrorism" };

        private List<string> locations = new List<string>
        { "Warsaw", "London", "Berlin", "Paris", "Moscow", "Dublin", "Amsterdam", "Rome", "Prague" };

        public Crime GetRandomCrimeSeed()
        {
            Crime crime = new Crime
            {
                Type = _randomGenerator.GetRandomElement(crimeTypes),
                Location = _randomGenerator.GetRandomElement(locations),
                Time = _randomGenerator.GetRandomDate(2017, 2018, true),
                Description = "Radnom description."
            };
            return crime;
        }
    }
}
