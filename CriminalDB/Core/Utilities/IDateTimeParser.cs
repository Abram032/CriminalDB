using System;

namespace CriminalDB.Core.Utilities
{
    public interface IDateTimeParser
    {
        DateTime Parse(string message = "");
    }
}