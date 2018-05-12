using System;
using System.Collections.Generic;
using System.Text;
using CriminalDB.Core.Utilities;

namespace CriminalDB.Persistence.Utilities
{
    public class RandomGenerator : IRandomGenerator
    {
        private Random random = new Random();

        public int GetRandomInt(int minValue = 0, int maxValue = 32) => random.Next(minValue, maxValue);
        public float GetRandomFloat() => (float)random.NextDouble();
        public T GetRandomElement<T>(List<T> list) => list[random.Next(0, list.Count)];
        
        public DateTime GetRandomDate(int minYear = 1970, int maxYear = 2000, bool withHours = false)
        {            
            int hours = 0;
            int minutes = 0;
            int year = random.Next(minYear, maxYear);
            int month = random.Next(1, 13);
            int day = random.Next(1, 28);
            if(withHours)
            {
                hours = random.Next(0, 24);
                minutes = random.Next(0, 60);
            }
            return new DateTime(year, month, day, hours, minutes, 0);     
        }
    }
}
