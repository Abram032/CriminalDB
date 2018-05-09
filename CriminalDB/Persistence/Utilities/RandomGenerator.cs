using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Utilities
{
    public class RandomGenerator
    {
        private static Random random = new Random();

        public static string GetValue(List<string> list)
        {
            int value = random.Next(0, 32);
            value = value % list.Count;
            return list[value];
        }

        public static int GetRandomInt(int minValue = 0, int maxValue = 32)
        {
            return random.Next(minValue, maxValue);
        }

        public static float GetRandomFloat()
        {
            return (float)random.NextDouble();
        }
    }
}
