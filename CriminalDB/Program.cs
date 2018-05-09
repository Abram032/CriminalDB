using CriminalDB.Core.DataModels;
using CriminalDB.Persistence.Context;
using System;
using System.Collections.Generic;
using static CriminalDB.Persistence.Utilities.ViewCrimes;
using static CriminalDB.Persistence.Utilities.ViewCriminals;
using static CriminalDB.Persistence.Utilities.AddCrimes;
using static CriminalDB.Persistence.Utilities.RemoveCrimes;
using System.IO;
using System.Threading.Tasks;

namespace CriminalDB
{
    //TODO: Get rid of data annotations and build constraints using Fluent API
    //TODO: Validation
    //TODO: IoC for Utilities
    //TODO: Upgrade adding, add removing, add more view options
    class Program
    {
        public static void InitDatabase() => new InitDatabase().Main();
        static Task Init = new Task(InitDatabase);
        
        public static void Menu() => new Menu().Main();
        static Task StartApp => new Task(Menu);

        static void Main(string[] args)
        {
            Init.Start();
            Init.Wait();
            StartApp.Start();
            StartApp.Wait();
        }
    }
}
