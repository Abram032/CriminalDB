using System;
using System.Collections.Generic;
using System.Globalization;
using CriminalDB.Core.Utilities;

namespace CriminalDB.Persistence.Utilities
{
    public class CommandPrompt
    {
        public static string Input(string message = "")
        {
            Console.WriteLine(message);
            Console.Write("> ");
            string result = new CultureInfo("en-US").TextInfo.ToTitleCase(Console.ReadLine());
            return result;
        }
        
        public static string Input<T>(IEnumerable<T> messages)
        {
            foreach(T message in messages)
                Console.WriteLine(message);
            Console.Write("> ");
            string result = new CultureInfo("en-US").TextInfo.ToTitleCase(Console.ReadLine());
            return result;
        }
    }
}