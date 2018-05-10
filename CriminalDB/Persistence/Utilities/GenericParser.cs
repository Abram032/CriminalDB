using System;
using System.Collections.Generic;
using static CriminalDB.Persistence.Utilities.CommandPrompt;
using System.Text;

namespace CriminalDB.Persistence.Utilities
{
    public class GenericParser
    {
        public static T ParseValue<T>(TryParseHandler<T> handler, string message = "") where T : struct
        {
            while(true)
            {
                string value = Input(message);
                if(handler(value, out T result))
                    return result;
                else
                    Console.WriteLine("Invalid value");
            }
        }

        public delegate bool TryParseHandler<T>(string value, out T result);

        //Usage:
        //var value = ParseValue<int>(int.TryParse, "message to show");
        //var value = ParseValue<double>(double.TryParse);
    }
}
