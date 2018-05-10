using CriminalDB.Core.DataModels;
using CriminalDB.Persistence.Context;
using CriminalDB.Persistence.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using static CriminalDB.Persistence.Utilities.GenericParser;
using static CriminalDB.Persistence.Utilities.CommandPrompt;

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
            while (menu)
            {
                Console.Clear();
                ShowMenu();
                var result = Input();             
                switch (result)
                {
                    case "x":
                        menu = false;
                        break;
                    case "1":
                        bool addmenu = true;
                        while(addmenu)
                        {
                            Console.Clear();
                            AddRemoveMenu();
                            result = Input();
                            switch(result)
                            {
                                case "x":
                                    addmenu = false;
                                    menu = false;
                                    break;
                                case "0":
                                    addmenu = false;
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
                            }
                        }
                        break;
                    case "2":
                        bool crimemenu = true;
                        while(crimemenu)
                        {
                            Console.Clear();
                            CrimeMenu();
                            result = Input();
                            switch(result)
                            {
                                case "x":
                                    crimemenu = false;
                                    menu = false;
                                    break;
                                case "0":
                                    crimemenu = false;
                                    break;
                                case "1":
                                    view.Crime();
                                    break;
                                case "2":
                                    view.Crime(true);
                                    break;
                                case "3":
                                    view.Crime(true, true);
                                    break;
                                case "4":
                                    view.AllCrimes();
                                    break;
                                case "5":
                                    view.AllCrimes(true);
                                    break;
                                case "6":
                                    view.AllCrimes(true, true);
                                    break;
                            }
                        }
                        break;
                    case "3":
                        bool criminalmenu = true;
                        while(criminalmenu)
                        {
                            Console.Clear();
                            CriminalMenu();
                            result = Input();
                            switch(result)
                            {
                                case "x":
                                    criminalmenu = false;
                                    menu = false;
                                    break;
                                case "0":
                                    criminalmenu = false;
                                    break;
                                case "1":
                                    view.Person<Criminal>();
                                    break;
                                case "2":
                                    view.Person<Criminal>(true);
                                    break;
                                case "3":
                                    view.Person<Criminal>(true, true);
                                    break;
                                case "4":
                                    view.Person<Criminal>(true, true, true);
                                    break;
                                case "5":
                                    view.AllPeople<Criminal>();
                                    break;
                                case "6":
                                    view.AllPeople<Criminal>(true);
                                    break;
                                case "7":
                                    view.AllPeople<Criminal>(true, true);
                                    break;
                                case "8":
                                    view.AllPeople<Criminal>(true, true, true);
                                    break;
                            }
                        }
                        break;
                    case "4":
                        bool victimmenu = true;
                        while(victimmenu)
                        {
                            Console.Clear();
                            VictimMenu();
                            result = Input();
                            switch(result)
                            {
                                case "x":
                                    victimmenu = false;
                                    menu = false;
                                    break;
                                case "0":
                                    victimmenu = false;
                                    break;
                                case "1":
                                    view.Person<Victim>();
                                    break;
                                case "2":
                                    view.Person<Victim>(true);
                                    break;
                                case "3":
                                    view.Person<Victim>(true, true);
                                    break;
                                case "4":
                                    view.Person<Victim>(true, true, true);
                                    break;
                                case "5":
                                    view.AllPeople<Victim>();
                                    break;
                                case "6":
                                    view.AllPeople<Victim>(true);
                                    break;
                                case "7":
                                    view.AllPeople<Victim>(true, true);
                                    break;
                                case "8":
                                    view.AllPeople<Victim>(true, true, true);
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Menu:");
            sb.AppendLine("1. Add/Remove");
            sb.AppendLine("2. View Crimes");
            sb.AppendLine("3. View Criminals");
            sb.AppendLine("4. View Victims");
            sb.AppendLine("x. Exit");
            Console.Write(sb);
        }

        private void AddRemoveMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Menu:");
            sb.AppendLine("1. New Crime");
            sb.AppendLine("2. Remove Crime");
            sb.AppendLine("3. Remove All Crimes");
            sb.AppendLine("4. Remove Criminal");
            sb.AppendLine("5. Remove All Criminals");
            sb.AppendLine("6. Remove Victim");
            sb.AppendLine("7. Remove All Victims");
            sb.AppendLine("0. Return.");
            sb.AppendLine("x. Exit.");
            Console.Write(sb);
        }

        private void CrimeMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Menu:");
            sb.AppendLine("1. View Crime ID");
            sb.AppendLine("2. View Crime ID (With Criminals)");
            sb.AppendLine("3. View Crime ID (With Criminals and Victims)");
            sb.AppendLine("4. View Crimes");
            sb.AppendLine("5. View Crimes (With Criminals)");
            sb.AppendLine("6. View Crimes (With Criminals and Victims)");
            sb.AppendLine("0. Return.");
            sb.AppendLine("x. Exit.");
            Console.Write(sb);
        }

        private void CriminalMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Menu:");
            sb.AppendLine("1. View Criminal");
            sb.AppendLine("2. View Criminal (With Details)");
            sb.AppendLine("3. View Criminal (With Details and Crimes)");
            sb.AppendLine("4. View Criminal (With Details and Crime Details)");
            sb.AppendLine("5. View Criminals");
            sb.AppendLine("6. View Criminals (With Details)");
            sb.AppendLine("7. View Criminals (With Details and Crimes)");
            sb.AppendLine("8. View Criminals (With Details and Crime Details)");
            sb.AppendLine("0. Return.");
            sb.AppendLine("x. Exit.");
            Console.Write(sb);
        }

        private void VictimMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Menu:");
            sb.AppendLine("1. View Victim");
            sb.AppendLine("2. View Victim (With Details)");
            sb.AppendLine("3. View Victim (With Details and Crimes)");
            sb.AppendLine("4. View Victim (With Details and Crime Details)");
            sb.AppendLine("5. View Victims");
            sb.AppendLine("6. View Victims (With Details)");
            sb.AppendLine("7. View Victims (With Details and Crimes)");
            sb.AppendLine("8. View Victims (With Details and Crime Details)");
            sb.AppendLine("0. Return.");
            sb.AppendLine("x. Exit.");
            Console.Write(sb);
        }
    }
}
