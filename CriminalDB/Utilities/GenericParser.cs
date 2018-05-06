using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Utilities
{
    public class GenericParser
    {
        public static T ParseValue<T>(TryParseHandler<T> handler, string message = "") where T : struct
        {
            while(true)
            {
                Console.WriteLine(message);
                string value = Console.ReadLine();
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
