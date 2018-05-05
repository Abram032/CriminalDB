using CriminalDB.Database.Model;
using CriminalDB.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Utilities
{
    public class ViewCrimes
    {
        public static void ViewAllCrimes(bool showCriminals = false, bool showVictims = false)
        {
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                IEnumerable<Crime> crimes = null;
                if (showCriminals == false && showVictims == false)
                    crimes = unitOfWork.CrimeRepository.GetCrimes();
                else if (showCriminals == true && showVictims == false)
                    crimes = unitOfWork.CrimeRepository.GetCrimesWithCriminals();
                else
                    crimes = unitOfWork.CrimeRepository.GetCrimesWithCriminalsAndVictims();
                if (crimes == null)
                    return;
                foreach (var crime in crimes)
                {
                    Console.WriteLine("ID: " + crime.CrimeID);
                    Console.WriteLine("Type: " + crime.Type);
                    Console.WriteLine("Time: " + crime.Time);
                    Console.WriteLine("Location: " + crime.Location);
                    Console.WriteLine("Description: " + crime.Description);
                    Console.WriteLine();
                    if (showCriminals)
                    {
                        Console.WriteLine("Criminals:");
                        foreach (var criminal in crime.Criminals)
                            Console.WriteLine(criminal.ID + ": " + criminal.FirstName + " " + criminal.LastName);
                        Console.WriteLine();
                    }
                    if (showVictims)
                    {
                        Console.WriteLine("Victims:");
                        foreach (var victim in crime.Victims)
                            Console.WriteLine(victim.ID + ": " + victim.FirstName + " " + victim.LastName);
                        Console.WriteLine();
                    }
                }
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        public static void ViewCrime(bool showCriminals = false, bool showVictims = false)
        {
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                Crime crime = null;
                Console.WriteLine("Crime ID:");
                string id = Console.ReadLine();
                if (int.TryParse(id, out int result) == false)
                {
                    Console.WriteLine("NaN");
                    return;
                }
                int _id = int.Parse(id);
                if (showCriminals == false && showVictims == false)
                    crime = unitOfWork.CrimeRepository.Get(_id);
                else if (showCriminals == true && showVictims == false)
                    crime = unitOfWork.CrimeRepository.GetCrimeWithCriminals(_id);
                else
                    crime = unitOfWork.CrimeRepository.GetCrimeWithCriminalsAndVictims(_id);
                if (crime == null)
                {
                    Console.WriteLine("Crime ID not found");
                    return;
                }
                Console.WriteLine("ID: " + crime.CrimeID);
                Console.WriteLine("Type: " + crime.Type);
                Console.WriteLine("Time: " + crime.Time);
                Console.WriteLine("Location: " + crime.Location);
                Console.WriteLine("Description: " + crime.Description);
                Console.WriteLine();
                if (showCriminals)
                {
                    Console.WriteLine("Criminals:");
                    foreach (var criminal in crime.Criminals)
                        Console.WriteLine(criminal.ID + ": " + criminal.FirstName + " " + criminal.LastName);
                    Console.WriteLine();
                }
                if (showVictims)
                {
                    Console.WriteLine("Victims:");
                    foreach (var victim in crime.Victims)
                        Console.WriteLine(victim.ID + ": " + victim.FirstName + " " + victim.LastName);
                    Console.WriteLine();
                }
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }
    }
}
