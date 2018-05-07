using CriminalDB.Core.DataModels;
using CriminalDB.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CriminalDB.Persistence.Utilities.GenericParser;

namespace CriminalDB.Persistence.Utilities
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
                        foreach (var criminal in crime.CrimeCriminals.Select(x => x.Criminal))
                            Console.WriteLine(criminal.ID + ": " + criminal.FirstName + " " + criminal.LastName);
                        Console.WriteLine();
                    }
                    if (showVictims)
                    {
                        Console.WriteLine("Victims:");
                        foreach (var victim in crime.CrimeVictims.Select(x => x.Victim))
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
                int id = ParseValue<int>(int.TryParse, "Criminal ID:");
                if (showCriminals == false && showVictims == false)
                    crime = unitOfWork.CrimeRepository.Get(id);
                else if (showCriminals == true && showVictims == false)
                    crime = unitOfWork.CrimeRepository.GetCrimeWithCriminals(id);
                else
                    crime = unitOfWork.CrimeRepository.GetCrimeWithCriminalsAndVictims(id);
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
                    foreach (var criminal in crime.CrimeCriminals.Select(x => x.Criminal))
                        Console.WriteLine(criminal.ID + ": " + criminal.FirstName + " " + criminal.LastName);
                    Console.WriteLine();
                }
                if (showVictims)
                {
                    Console.WriteLine("Victims:");
                    foreach (var victim in crime.CrimeVictims.Select(x => x.Victim))
                        Console.WriteLine(victim.ID + ": " + victim.FirstName + " " + victim.LastName);
                    Console.WriteLine();
                }
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }
    }
}
