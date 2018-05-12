using System;
using CriminalDB.Core.Utilities;
using static CriminalDB.Persistence.Utilities.CommandPrompt;

namespace CriminalDB.Persistence.Utilities 
{
    public class DateTimeParser : IDateTimeParser
    {
        public DateTime Parse (string message = "") 
        {
            //DateTime format: DD-MM-YYYY HH:MM:SS
            //DateTime format: DD-MM-YYYY HH:MM
            //DateTime format: DD-MM-YYYY
            while (true) 
            {
                string dateTime = Input(message);
                if (DateTime.TryParse (dateTime, out DateTime result))
                    return result;
                else
                    Console.WriteLine("Invalid date or format!");
            }

        }
    }
}