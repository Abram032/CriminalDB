using CriminalDB.Core.DataModels;
using CriminalDB.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using static CriminalDB.Persistence.Utilities.GenericParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Utilities
{
    public class CrimeForm : ICrimeForm
    {
        private DbContext _context;

        public CrimeForm(DbContext context)
        {
            _context = context;
        }

        #region Adding

        public void AddCrime()
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                int amount;
                Crime crime = new Crime();
                crime = CrimeInfo(crime);
                Console.WriteLine();
                //Adding to databse
                unitOfWork.CrimeRepository.Add(crime);

                amount = ParseValue<int>(int.TryParse, "How many criminals?");
                for (int i = 0; i < amount; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Criminal {0}:", i + 1);
                    Criminal criminal = new Criminal();
                    criminal = Info(criminal);

                    //Adding to fields
                    CrimeCriminal crimeCriminal = new CrimeCriminal();
                    crimeCriminal.Criminal = criminal;
                    crimeCriminal.Crime = crime;
                    criminal.Crimes.Add(crimeCriminal);
                    crime.CrimeCriminals.Add(crimeCriminal);

                    //Adding to databse
                    unitOfWork.CriminalRepository.Add(criminal);
                    unitOfWork.CrimeCriminalRepository.Add(crimeCriminal);
                }
                amount = ParseValue<int>(int.TryParse, "How many victims?");
                for (int i = 0; i < amount; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Victim {0}:", i + 1);
                    Victim victim = new Victim();
                    victim = Info(victim);

                    //Adding to fields
                    CrimeVictim crimeVictim = new CrimeVictim();
                    crimeVictim.Victim = victim;
                    crimeVictim.Crime = crime;
                    victim.Crimes.Add(crimeVictim);
                    crime.CrimeVictims.Add(crimeVictim);

                    //Adding to databse
                    //unitOfWork.VictimRepository.Add(victim);
                    //unitOfWork.CrimeVictimRepository.Add(crimeVictim);
                }

                //Add data from lists to database    
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        private Crime CrimeInfo(Crime crime)
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
        
        private T Info<T>(T person) where T : Person
        {
            DateTime time = DateTime.Now;
            Console.WriteLine("First name:");
            person.FirstName = Console.ReadLine();
            Console.WriteLine("Last name:");
            person.LastName = Console.ReadLine();
            Console.WriteLine("Nationality:");
            person.Nationality = Console.ReadLine();
            person.DateOfBirth = time;
            //Gender
            while (true)
            {
                Console.WriteLine("Gender (m/f):");
                string _gender = Console.ReadLine();
                if (_gender.StartsWith('m'))
                {
                    person.Gender = Enums.Gender.Male;
                    break;
                }
                else if (_gender.StartsWith('f'))
                {
                    person.Gender = Enums.Gender.Female;
                    break;
                }
                else
                    Console.WriteLine("Invalid gender!");
            }
            person.Height = ParseValue<float>(float.TryParse, "Height:");
            person.Weight = ParseValue<float>(float.TryParse, "Weight:");
            Console.WriteLine("Address:");
            person.Address = Console.ReadLine();
            Console.WriteLine("Photo:");
            person.Photo = Console.ReadLine();
            //Console.WriteLine("Description:");
            //person.Description = Console.ReadLine();
            return person;
        }

        #endregion

        #region Removing

        public void Remove<TEntity>() where TEntity : class
        {
            int id = ParseValue<int>(int.TryParse, "Crime ID:");
            using (var unitOfWork = new UnitOfWork(_context))
            {
                var entity = unitOfWork.Repository<TEntity>().Get(id);
                if (entity == null)
                {
                    Console.WriteLine("No entity with such id.");
                    return;
                }
                unitOfWork.Repository<TEntity>().Remove(entity);
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        public void RemoveAll<TEntity>() where TEntity : class
        {
            using (var unitOfWork = new UnitOfWork(_context))
            {
                var entities = unitOfWork.Repository<TEntity>().GetAll();
                unitOfWork.Repository<TEntity>().RemoveRange(entities);
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        #endregion
    }
}
