using CriminalDB.Core.DataModels;
using CriminalDB.Persistence.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CriminalDB
{
    //TODO: Validation
    //TODO: Upgrade adding
    //TODO: Add more functions for custom repositories and use them for viewing
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
