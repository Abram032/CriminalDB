using CriminalDB.Core.DataModels;
using CriminalDB.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using static CriminalDB.Persistence.Utilities.GenericParser;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CriminalDB.Persistence.Utilities
{
    public class ViewForm : IViewForm
    {
        private DbContext _context;

        public ViewForm(DbContext context)
        {
            _context = context;
        }

        #region Crimes

        public void Crime(bool showCriminals = false, bool showVictims = false)
        {
            using (var unitOfWork = new UnitOfWork(_context))
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

        public void AllCrimes(bool showCriminals = false, bool showVictims = false)
        {
            using (var unitOfWork = new UnitOfWork(_context))
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

        #endregion

        #region Criminals

        public void Criminal(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false)
        {
            int id = ParseValue<int>(int.TryParse, "Criminal ID:");
            using (var unitOfWork = new UnitOfWork(_context))
            {
                var criminal = unitOfWork.CriminalRepository.Get(id);
                if (criminal == null)
                {
                    Console.WriteLine("No criminal with such id");
                    return;
                }
                Console.WriteLine("ID: " + criminal.ID);
                Console.WriteLine("Name: " + criminal.FirstName + " " + criminal.LastName);
                if (showDetails)
                {

                }
                if (showCrimes)
                {

                }
                if (showCrimesDetails)
                {

                }
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        public void AllCriminals(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                var criminals = unitOfWork.CriminalRepository.GetAll();
                foreach (var criminal in criminals)
                {
                    Console.WriteLine("ID: " + criminal.ID);
                    Console.WriteLine("Name: " + criminal.FirstName + " " + criminal.LastName);
                    if (showDetails)
                    {

                    }
                    if (showCrimes)
                    {

                    }
                    if (showCrimesDetails)
                    {

                    }
                }
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        #endregion

        #region Victims

        public void Victim(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false)
        {
            int id = ParseValue<int>(int.TryParse, "Victim ID:");
            using (var unitOfWork = new UnitOfWork(_context))
            {
                var criminal = unitOfWork.CriminalRepository.Get(id);
                if (criminal == null)
                {
                    Console.WriteLine("No victim with such id");
                    return;
                }
                Console.WriteLine("ID: " + criminal.ID);
                Console.WriteLine("Name: " + criminal.FirstName + " " + criminal.LastName);
                if (showDetails)
                {

                }
                if (showCrimes)
                {

                }
                if (showCrimesDetails)
                {

                }
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        public void AllVictims(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false)
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                var criminals = unitOfWork.CriminalRepository.GetAll();
                foreach (var criminal in criminals)
                {
                    Console.WriteLine("ID: " + criminal.ID);
                    Console.WriteLine("Name: " + criminal.FirstName + " " + criminal.LastName);
                    if (showDetails)
                    {

                    }
                    if (showCrimes)
                    {

                    }
                    if (showCrimesDetails)
                    {

                    }
                }
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        #endregion
    }
}
