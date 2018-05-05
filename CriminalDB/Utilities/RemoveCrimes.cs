using CriminalDB.Database.Model;
using CriminalDB.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Utilities
{
    public class RemoveCrimes
    {
        public static void RemoveCrime()
        {
            Console.WriteLine("Crime ID:");
            string id = Console.ReadLine();
            if (int.TryParse(id, out int result) == false)
            {
                Console.WriteLine("NaN");
                return;
            }
            int _id = int.Parse(id);
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                Crime crime = unitOfWork.CrimeRepository.Get(_id);
                if (crime == null)
                {
                    Console.WriteLine("No crime with such id.");
                    return;
                }
                unitOfWork.CrimeRepository.Remove(crime);
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        public static void RemoveAllCrimes()
        {
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                var crimes = unitOfWork.CrimeRepository.GetAll();
                unitOfWork.CrimeRepository.RemoveRange(crimes);
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }
    }
}
