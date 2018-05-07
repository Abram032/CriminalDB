using CriminalDB.Core.DataModels;
using CriminalDB.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using static CriminalDB.Persistence.Utilities.GenericParser;

namespace CriminalDB.Persistence.Utilities
{
    public class RemoveCrimes
    {
        public static void RemoveCrime()
        {
            int id = ParseValue<int>(int.TryParse, "Crime ID:");
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                Crime crime = unitOfWork.CrimeRepository.Get(id);
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
