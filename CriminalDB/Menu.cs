using CriminalDB.Core.DataModels;
using CriminalDB.Persistence.Context;
using CriminalDB.Persistence.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB
{
    public class Menu
    {
        public void Main()
        {
            CriminalContext context = new CriminalContext();
            ViewForm view = new ViewForm();
            CrimeForm form = new CrimeForm();

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
                        form.AddCrime();
                        break;
                    case "2":
                        form.Remove<Crime>();
                        break;
                    case "3":
                        form.RemoveAll<Crime>();
                        break;
                    case "4":
                        form.Remove<Criminal>();
                        break;
                    case "5":
                        form.RemoveAll<Criminal>();
                        break;
                    case "6":
                        form.Remove<Victim>();
                        break;
                    case "7":
                        form.RemoveAll<Victim>();
                        break;
                    case "10":
                        view.AllCrimes();
                        break;
                    case "11":
                        view.AllCrimes(true);
                        break;
                    case "12":
                        view.AllCrimes(true, true);
                        break;
                    case "13":
                        view.Crime();
                        break;
                    case "14":
                        view.Crime(true);
                        break;
                    case "15":
                        view.Crime(true, true);
                        break;
                    case "20":
                        view.AllPeople<Criminal>();
                        break;
                    case "21":
                        view.AllPeople<Criminal>(true);
                        break;
                    case "22":
                        view.AllPeople<Criminal>(true, true);
                        break;
                    case "23":
                        view.AllPeople<Criminal>(true, true, true);
                        break;
                    case "24":
                        view.Person<Criminal>();
                        break;
                    case "25":
                        view.Person<Criminal>(true);
                        break;
                    case "26":
                        view.Person<Criminal>(true, true);
                        break;
                    case "27":
                        view.Person<Criminal>(true, true, true);
                        break;
                    case "30":
                        view.AllPeople<Victim>();
                        break;
                    case "31":
                        view.AllPeople<Victim>(true);
                        break;
                    case "32":
                        view.AllPeople<Victim>(true, true);
                        break;
                    case "33":
                        view.AllPeople<Victim>(true, true, true);
                        break;
                    case "34":
                        view.Person<Victim>();
                        break;
                    case "35":
                        view.Person<Victim>(true);
                        break;
                    case "36":
                        view.Person<Victim>(true, true);
                        break;
                    case "37":
                        view.Person<Victim>(true, true, true);
                        break;
                    default:
                        Console.WriteLine("Unknown option");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. New Crime");
            Console.WriteLine("2. Remove Crime");
            Console.WriteLine("3. Remove All Crimes");
            Console.WriteLine("4. Remove Criminal");
            Console.WriteLine("5. Remove All Criminals");
            Console.WriteLine("6. Remove Victim");
            Console.WriteLine("7. Remove All Victims");
            Console.WriteLine();
            Console.WriteLine("10. View Crimes");
            Console.WriteLine("11. View Crimes (With Criminals)");
            Console.WriteLine("12. View Crimes (With Criminals and Victims)");
            Console.WriteLine("13. View Crime ID");
            Console.WriteLine("14. View Crime ID (With Criminals)");
            Console.WriteLine("15. View Crime ID (With Criminals and Victims)");
            Console.WriteLine();
            Console.WriteLine("20. View Criminals");
            Console.WriteLine("21. View Criminals (With Details)");
            Console.WriteLine("22. View Criminals (With Details and Crimes)");
            Console.WriteLine("23. View Criminals (With Details and Crime Details)");
            Console.WriteLine("24. View Criminal");
            Console.WriteLine("25. View Criminal (With Details)");
            Console.WriteLine("26. View Criminal (With Details and Crimes)");
            Console.WriteLine("27. View Criminal (With Details and Crime Details)");
            Console.WriteLine();
            Console.WriteLine("30. View Victims");
            Console.WriteLine("31. View Victims (With Details)");
            Console.WriteLine("32. View Victims (With Details and Crimes)");
            Console.WriteLine("33. View Victims (With Details and Crime Details)");
            Console.WriteLine("34. View Victim");
            Console.WriteLine("35. View Victim (With Details)");
            Console.WriteLine("36. View Victim (With Details and Crimes)");
            Console.WriteLine("37. View Victim (With Details and Crime Details)");
            Console.WriteLine();
            Console.WriteLine("0. Exit");
        }
    }
}
