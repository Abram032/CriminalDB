using CriminalDB.Core.DataModels;
using CriminalDB.Core.DataSeeder;
using CriminalDB.Core.Utilities;
using CriminalDB.Core.EntityValidator;
using CriminalDB.Persistence.Context;
using CriminalDB.Persistence.DataSeeder;
using CriminalDB.Persistence.Utilities;
using CriminalDB.Persistence.EntityValidator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CriminalDB
{
    //TODO: Test adding new crime to DB.
    //TODO: Add descriptions for functions
    //TODO: Tests
    class Program
    {
        static int amountOfSeeds = 50;
        static IDateTimeParser dateParser = new DateTimeParser();
        static IEntityValidator validator = new EntityValidator();
        static IRandomGenerator randomGenerator = new RandomGenerator();
        static IViewForm view = new ViewForm();
        static ICrimeForm form = new CrimeForm(dateParser, validator);
        static IPersonSeeder personSeeder = new PersonSeeder(randomGenerator);
        static ICrimeSeeder crimeSeeder = new CrimeSeeder(randomGenerator);
        static ISeeder seeder = new Seeder(randomGenerator, crimeSeeder, personSeeder);

        public static void InitDatabase() => new InitDatabase(seeder, amountOfSeeds).Main();
        static Task Init = new Task(InitDatabase);
        
        public static void Menu() => new Menu(form, view, dateParser).Main();
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
