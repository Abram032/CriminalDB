using CriminalDB.Database.Model;
using CriminalDB.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using static CriminalDB.Utilities.GenericParser;

namespace CriminalDB.Utilities
{
    public class AddCrimes
    {
        public static void NewCrime()
        {
            int amount;
            Crime crime = new Crime();
            crime = CrimeInfo(crime);
            Console.WriteLine();
            amount = ParseValue<int>(int.TryParse, "How many criminals?");
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Criminal {0}:", i + 1);
                Criminal criminal = new Criminal();
                criminal = CriminalInfo(criminal);
                criminal.Crimes.Add(new CrimeCriminal { Crime = crime, Criminal = criminal });
                crime.CrimeCriminals.Add(new CrimeCriminal { Crime = crime, Criminal = criminal });
            }
            amount = ParseValue<int>(int.TryParse, "How many victims?");
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Victim {0}:", i + 1);
                Victim victim = new Victim();
                victim = VictimInfo(victim);
                crime.CrimeVictims.Add(new CrimeVictim { Crime = crime, Victim = victim });
                //victims.Add(victim);
            }
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                //Add data to database
                unitOfWork.CrimeRepository.Add(crime);
                //unitOfWork.CriminalRepository.AddRange(criminals);
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        private static Crime CrimeInfo(Crime crime)
        {
            DateTime time = DateTime.Now;
            Console.WriteLine("Type:");
            crime.Type = Console.ReadLine();
            crime.Time = time;
            Console.WriteLine("Location:");
            crime.Location = Console.ReadLine();
            Console.WriteLine("Description:");
            crime.Description = Console.ReadLine();
            return crime;
        }

        private static Criminal CriminalInfo(Criminal criminal)
        {
            DateTime time = DateTime.Now;
            Console.WriteLine("First name:");
            criminal.FirstName = Console.ReadLine();
            Console.WriteLine("Last name:");
            criminal.LastName = Console.ReadLine();
            Console.WriteLine("Nationality:");
            criminal.Nationality = Console.ReadLine();
            criminal.DateOfBirth = time;
            //Gender
            while (true)
            {
                Console.WriteLine("Gender (m/f):");
                string _gender = Console.ReadLine();
                if (_gender.StartsWith('m'))
                {
                    criminal.Gender = Enums.Gender.Male;
                    break;
                }
                else if (_gender.StartsWith('f'))
                {
                    criminal.Gender = Enums.Gender.Female;
                    break;
                }
                else
                    Console.WriteLine("Invalid gender!");
            }
            criminal.Height = ParseValue<double>(double.TryParse, "Height:");
            criminal.Weight = ParseValue<double>(double.TryParse, "Weight:");
            Console.WriteLine("Address:");
            criminal.Address = Console.ReadLine();
            Console.WriteLine("Photo:");
            criminal.Photo = Console.ReadLine();
            Console.WriteLine("Description:");
            criminal.Description = Console.ReadLine();
            return criminal;
        }

        private static Victim VictimInfo(Victim victim)
        {
            DateTime time = DateTime.Now;
            Console.WriteLine("First name:");
            victim.FirstName = Console.ReadLine();
            Console.WriteLine("Last name:");
            victim.LastName = Console.ReadLine();
            Console.WriteLine("Nationality:");
            victim.Nationality = Console.ReadLine();
            victim.DateOfBirth = time;
            //Gender
            while (true)
            {
                Console.WriteLine("Gender (m/f):");
                string _gender = Console.ReadLine();
                if (_gender.StartsWith('m'))
                {
                    victim.Gender = Enums.Gender.Male;
                    break;
                }
                else if (_gender.StartsWith('f'))
                {
                    victim.Gender = Enums.Gender.Female;
                    break;
                }
                else
                    Console.WriteLine("Invalid gender!");
            }
            victim.Height = ParseValue<double>(double.TryParse, "Height:");
            victim.Weight = ParseValue<double>(double.TryParse, "Weight:");
            Console.WriteLine("Address:");
            victim.Address = Console.ReadLine();
            Console.WriteLine("Photo:");
            victim.Photo = Console.ReadLine();
            return victim;
        }  
    }
}
