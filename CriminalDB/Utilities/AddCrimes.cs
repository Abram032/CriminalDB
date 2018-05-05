using CriminalDB.Database.Model;
using CriminalDB.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Utilities
{
    public class AddCrimes
    {
        public static void NewCrime()
        {
            Crime crime = new Crime();
            List<Criminal> criminals = new List<Criminal>();
            List<Victim> victims = new List<Victim>();
            DateTime time = DateTime.Now;
            int amount;
            Console.WriteLine("Type:");
            crime.Type = Console.ReadLine();
            crime.Time = time;
            Console.WriteLine("Location:");
            crime.Location = Console.ReadLine();
            Console.WriteLine("Description:");
            crime.Description = Console.ReadLine();
            Console.WriteLine("How many criminals?");
            string _amount = Console.ReadLine();
            if (int.TryParse(_amount, out int amnt) == false)
            {
                Console.WriteLine("NaN");
                return;
            }
            amount = int.Parse(_amount);
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Criminal {0}:", i+1);
                Console.WriteLine();
                Criminal criminal = new Criminal();
                Console.WriteLine("First name:");
                criminal.FirstName = Console.ReadLine();
                Console.WriteLine("Last name:");
                criminal.LastName = Console.ReadLine();
                Console.WriteLine("Nationality:");
                criminal.Nationality = Console.ReadLine();
                Console.WriteLine("Gender (m/f):");
                string _gender = Console.ReadLine();
                if (_gender.StartsWith('m'))
                    criminal.Gender = Enums.Gender.Male;
                else if (_gender.StartsWith('f'))
                    criminal.Gender = Enums.Gender.Female;
                else
                {
                    Console.WriteLine("Invalid gender!");
                    return;
                }
                criminal.DateOfBirth = time;
                Console.WriteLine("Height:");
                string _height = Console.ReadLine();
                if (double.TryParse(_height, out double he) == false)
                {
                    Console.WriteLine("NaN");
                    return;
                }
                criminal.Height = double.Parse(_height);
                Console.WriteLine("Weight:");
                string _weight = Console.ReadLine();
                if (double.TryParse(_weight, out double we) == false)
                {
                    Console.WriteLine("NaN");
                    return;
                }
                criminal.Weight = double.Parse(_weight);
                Console.WriteLine("Address:");
                criminal.Address = Console.ReadLine();
                Console.WriteLine("Photo:");
                criminal.Photo = Console.ReadLine();
                Console.WriteLine("Description:");
                criminal.Description = Console.ReadLine();
                criminals.Add(criminal);
            }
            Console.WriteLine("How many victims?");
            _amount = Console.ReadLine();
            if (int.TryParse(_amount, out int amnt2) == false)
            {
                Console.WriteLine("NaN");
                return;
            }
            amount = int.Parse(_amount);
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Victim {0}:", i+1);
                Console.WriteLine();
                Victim victim = new Victim();
                Console.WriteLine("First name:");
                victim.FirstName = Console.ReadLine();
                Console.WriteLine("Last name:");
                victim.LastName = Console.ReadLine();
                Console.WriteLine("Nationality:");
                victim.Nationality = Console.ReadLine();
                Console.WriteLine("Gender (m/f):");
                string _gender = Console.ReadLine();
                if (_gender.StartsWith('m'))
                    victim.Gender = Enums.Gender.Male;
                else if (_gender.StartsWith('f'))
                    victim.Gender = Enums.Gender.Female;
                else
                {
                    Console.WriteLine("Invalid gender!");
                    return;
                }
                victim.DateOfBirth = time;
                Console.WriteLine("Height:");
                string _height = Console.ReadLine();
                if (double.TryParse(_height, out double he) == false)
                {
                    Console.WriteLine("NaN");
                    return;
                }
                victim.Height = double.Parse(_height);
                Console.WriteLine("Weight:");
                string _weight = Console.ReadLine();
                if (double.TryParse(_weight, out double we) == false)
                {
                    Console.WriteLine("NaN");
                    return;
                }
                victim.Weight = double.Parse(_weight);
                Console.WriteLine("Address:");
                victim.Address = Console.ReadLine();
                Console.WriteLine("Photo:");
                victim.Photo = Console.ReadLine();
                victims.Add(victim);
            }
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                //Add data to database
                unitOfWork.CrimeRepository.Add(crime);
                unitOfWork.CriminalRepository.AddRange(criminals);
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }
    }
}
