using CriminalDB.Core.DataModels;
using CriminalDB.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using static CriminalDB.Persistence.Utilities.GenericParser;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CriminalDB.Persistence.Context;

namespace CriminalDB.Persistence.Utilities
{
    public class ViewForm : IViewForm
    {
        public void Crime(bool showCriminals = false, bool showVictims = false)
        {
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                Crime crime = null;
                int id = ParseValue<int>(int.TryParse, "Crime ID:");
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
                Console.WriteLine("ID: " + crime.ID);
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

        public void AllCrimes(bool showCriminals = false, bool showVictims = false)
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
                    Console.WriteLine("ID: " + crime.ID);
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

        public void Person<TEntity>(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false) where TEntity : Person
        {
            int id = ParseValue<int>(int.TryParse, "ID:");
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                var person = unitOfWork.Repository<TEntity>().Get(id);
                if (person == null)
                {
                    Console.WriteLine("No person with such id");
                    return;
                }
                Console.WriteLine();
                Console.WriteLine("ID: " + person.ID);
                Console.WriteLine("Name: " + person.FirstName + " " + person.LastName);
                if (showDetails)
                {
                    Console.WriteLine("Gender: " + person.Gender);
                    Console.WriteLine("Nationality: " + person.Nationality);
                    Console.WriteLine("Date of birth: " + person.DateOfBirth);
                    Console.WriteLine("Height: " + person.Height);
                    Console.WriteLine("Weight: " + person.Weight);
                    Console.WriteLine("Address: " + person.Address);
                    Console.WriteLine("Photo: " + person.Photo);
                    var criminal = person as Criminal;
                    if (criminal != null)
                        Console.WriteLine("Description: " + criminal.Description);
                }
                if (showCrimes)
                {
                    Console.WriteLine("Crimes:");
                    var criminal = person as Criminal;
                    if (criminal != null)
                    {
                        foreach (var crime in criminal.Crimes)
                        {
                            Console.WriteLine("ID: " + crime.CrimeID);
                            Console.WriteLine("Type: " + crime.Crime.Type);
                            if (showCrimesDetails)
                            {
                                Console.WriteLine("Time: " + crime.Crime.Time);
                                Console.WriteLine("Location: " + crime.Crime.Location);
                                Console.WriteLine("Description: " + crime.Crime.Description);
                            }
                        }
                    }
                    var victim = person as Victim;
                    if (victim != null)
                    {
                        foreach (var crime in victim.Crimes)
                        {
                            Console.WriteLine("ID: " + crime.CrimeID);
                            Console.WriteLine("Type: " + crime.Crime.Type);
                            if (showCrimesDetails)
                            {
                                Console.WriteLine("Time: " + crime.Crime.Time);
                                Console.WriteLine("Location: " + crime.Crime.Location);
                                Console.WriteLine("Description: " + crime.Crime.Description);
                            }
                        }
                    }
                }
                unitOfWork.Complete();
            }
            Console.WriteLine();
            Console.WriteLine("Done.");
        }

        public void AllPeople<TEntity>(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false) where TEntity : Person
        {
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                var people = unitOfWork.Repository<TEntity>().GetAll();
                foreach (var person in people)
                {
                    Console.WriteLine();
                    Console.WriteLine("ID: " + person.ID);
                    Console.WriteLine("Name: " + person.FirstName + " " + person.LastName);
                    if (showDetails)
                    {
                        Console.WriteLine("Gender: " + person.Gender);
                        Console.WriteLine("Nationality: " + person.Nationality);
                        Console.WriteLine("Date of birth: " + person.DateOfBirth);
                        Console.WriteLine("Height: " + person.Height);
                        Console.WriteLine("Weight: " + person.Weight);
                        Console.WriteLine("Address: " + person.Address);
                        Console.WriteLine("Photo: " + person.Photo);
                        var criminal = person as Criminal;
                        if (criminal != null)
                            Console.WriteLine("Description: " + criminal.Description);
                    }
                    if (showCrimes)
                    {
                        Console.WriteLine("Crimes:");
                        var criminal = person as Criminal;
                        if (criminal != null)
                        {
                            foreach (var crime in criminal.Crimes)
                            {
                                Console.WriteLine("ID: " + crime.CrimeID);
                                Console.WriteLine("Type: " + crime.Crime.Type);
                                if (showCrimesDetails)
                                {
                                    Console.WriteLine("Time: " + crime.Crime.Time);
                                    Console.WriteLine("Location: " + crime.Crime.Location);
                                    Console.WriteLine("Description: " + crime.Crime.Description);
                                }
                            }
                        }
                        var victim = person as Victim;
                        if (victim != null)
                        {
                            foreach (var crime in victim.Crimes)
                            {
                                Console.WriteLine("ID: " + crime.CrimeID);
                                Console.WriteLine("Type: " + crime.Crime.Type);
                                if (showCrimesDetails)
                                {
                                    Console.WriteLine("Time: " + crime.Crime.Time);
                                    Console.WriteLine("Location: " + crime.Crime.Location);
                                    Console.WriteLine("Description: " + crime.Crime.Description);
                                }
                            }
                        }
                    }
                }
                unitOfWork.Complete();
            }
            Console.WriteLine();
            Console.WriteLine("Done.");
        }
    }
}
