using System;
using System.Collections.Generic;
using CriminalDB.Core.Utilities;

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
        
        public static string Input<T>(IEnumerable<T> messages)
        {
            foreach(T message in messages)
                Console.WriteLine(message);
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}