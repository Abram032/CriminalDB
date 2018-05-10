using System;
using System.Collections.Generic;

namespace CriminalDB.Persistence.Utilities
{
    public class CommandPrompt
    {
        public static string Input(string message = "")
        {
            Console.WriteLine(message);
            Console.Write("> ");
            return Console.ReadLine();
        }
        
        public static string Input(IEnumerable<string> messages)
        {
            foreach(string message in messages)
                Console.WriteLine(message);
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}