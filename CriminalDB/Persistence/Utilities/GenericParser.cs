using System;
using System.Collections.Generic;
using static CriminalDB.Persistence.Utilities.CommandPrompt;
using System.Text;
using CriminalDB.Core.Utilities;

namespace CriminalDB.Persistence.Utilities
{
    public class GenericParser : IGenericParser
    {   
        /// <summary>
        /// Parses Value
        /// </summary>   
        public T ParseValue<T>(Core.Utilities.TryParseHandler<T> handler, string message = "") where T : struct
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
        //Usage:
        //var value = ParseValue<int>(int.TryParse, "message to show");
        //var value = ParseValue<double>(double.TryParse);
    }
}
