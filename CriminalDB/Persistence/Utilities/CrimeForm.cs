using CriminalDB.Core.DataModels;
using CriminalDB.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using static CriminalDB.Persistence.Utilities.GenericParser;
using static CriminalDB.Persistence.Utilities.CommandPrompt;
using System;
using System.Collections.Generic;
using System.Text;
using CriminalDB.Persistence.Context;

namespace CriminalDB.Persistence.Utilities
{
    public class CrimeForm : ICrimeForm
    {
        public void AddCrime()
        {
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
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
                    Criminal criminal = new Criminal();
                    CrimeCriminal crimeCriminal = new CrimeCriminal();
                    if(QuestionLoop("Is criminal in database? (y/n)"))
                    {
                        int id = ParseValue<int>(int.TryParse, "Criminal ID: ");
                        criminal = unitOfWork.Repository<Criminal>().Get(id);                       
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Criminal {0}:", i + 1);
                        criminal = Info(criminal);
                        unitOfWork.CriminalRepository.Add(criminal);
                    }
                    crimeCriminal.Criminal = criminal;
                    crimeCriminal.Crime = crime;
                    criminal.Crimes.Add(crimeCriminal);
                    crime.CrimeCriminals.Add(crimeCriminal);
                    unitOfWork.Repository<CrimeCriminal>().Add(crimeCriminal);
                }
                amount = ParseValue<int>(int.TryParse, "How many victims?");
                for (int i = 0; i < amount; i++)
                {
                    Victim victim = new Victim();
                    if(QuestionLoop("Is criminal in database? (y/n)"))
                    {
                        int id = ParseValue<int>(int.TryParse, "Victim ID: ");
                        victim = unitOfWork.Repository<Victim>().Get(id);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Victim {0}:", i + 1);
                        victim = Info(victim);
                    }

                    //Adding to fields
                    CrimeVictim crimeVictim = new CrimeVictim();
                    crimeVictim.Victim = victim;
                    crimeVictim.Crime = crime;
                    victim.Crimes.Add(crimeVictim);
                    crime.CrimeVictims.Add(crimeVictim);

                    //Adding to databse
                    unitOfWork.VictimRepository.Add(victim);
                    unitOfWork.Repository<CrimeVictim>().Add(crimeVictim);
                }

                //Add data from lists to database    
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        private Crime CrimeInfo(Crime crime)
        {
            DateTime time = DateTime.Now;
            crime.Type = Input("Type:");
            crime.Time = time;
            crime.Location = Input("Location:");
            crime.Description = Input("Description:");
            return crime;
        }
        
        private TEntity Info<TEntity>(TEntity person) where TEntity : Person
        {
            DateTime time = DateTime.Now;
            person.FirstName = Input("First Name:");
            person.LastName = Input("Last Name:");
            person.Nationality = Input("Nationality:");
            person.DateOfBirth = time;
            //Gender
            while (true)
            {
                string _gender = Input("Gender (m/f):");
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
            person.Address = Input("Address:");
            person.Photo = Input("Photo:");
            var criminal = person as Criminal;
            if(criminal != null)
                criminal.Description = Input("Description:");
            return person;
        }

        public void Remove<TEntity>() where TEntity : class
        {
            int id = ParseValue<int>(int.TryParse, "Crime ID:");
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
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
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                var entities = unitOfWork.Repository<TEntity>().GetAll();
                unitOfWork.Repository<TEntity>().RemoveRange(entities);
                unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
        }

        private bool QuestionLoop(string message)
        {
            while(true)
            {
                var result = Input(message);
                if(result.Equals("y"))
                    return true;
                else if(result.Equals("n"))
                    return false;
                else
                    Console.Write("Invalid option.");
            }
        }
    }
}
