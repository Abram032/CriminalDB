using CriminalDB.Database.Model;
using CriminalDB.Repository.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using static CriminalDB.Utilities.ViewCrimes;
using static CriminalDB.Utilities.ViewCriminals;
using static CriminalDB.Utilities.AddCrimes;
using static CriminalDB.Utilities.RemoveCrimes;

namespace CriminalDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CriminalContext())
            {
                context.Database.Migrate();
            }
            bool menu = true;

            Console.WriteLine("Press any key to start");
            while (menu)
            {
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
                ShowMenu();
                var result = Console.ReadLine();
                switch (result)
                {
                    case "0":
                        menu = false;
                        break;
                    case "1":
                        NewCrime();
                        break;
                    case "10":
                        ViewAllCrimes();
                        break;
                    case "11":
                        ViewAllCrimes(true);
                        break;
                    case "12":
                        ViewAllCrimes(true, true);
                        break;
                    case "13":
                        ViewCrime();
                        break;
                    case "14":
                        ViewCrime(true);
                        break;
                    case "15":
                        ViewCrime(true, true);
                        break;
                    case "x":
                        RemoveCrime();
                        break;
                    case "xa":
                        RemoveAllCrimes();
                        break;
                    case "20":
                        ViewAllCriminals();
                        break;
                    case "21":
                        ViewCriminal();
                        break;
                    default:
                        Console.WriteLine("Unknown option");
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. New Crime");
            Console.WriteLine("10. View Crimes");
            Console.WriteLine("11. View Crimes (With Criminals)");
            Console.WriteLine("12. View Crimes (With Criminals and Victims)");
            Console.WriteLine("13. View Crime ID");
            Console.WriteLine("14. View Crime ID (With Criminals)");
            Console.WriteLine("15. View Crime ID (With Criminals and Victims)");
            Console.WriteLine("20. View Criminals");
            Console.WriteLine("21. View Criminal ID");
            Console.WriteLine("x. Remove Crime ID");
            Console.WriteLine("xa. Remove all Crimes");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }
    }
}
