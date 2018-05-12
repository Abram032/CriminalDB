using System;
using System.Collections.Generic;

namespace CriminalDB.Core.Utilities
{
    public interface IRandomGenerator
    {
        int GetRandomInt(int minValue = 0, int maxValue = 32);
        float GetRandomFloat();
        T GetRandomElement<T>(List<T> list);
        DateTime GetRandomDate(int minYear = 1970, int maxYear = 2000, bool withHours = false);
    }
}