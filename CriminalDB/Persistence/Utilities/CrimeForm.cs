using CriminalDB.Core.DataModels;
using CriminalDB.Core.Utilities;
using Microsoft.EntityFrameworkCore;
using static CriminalDB.Persistence.Utilities.GenericParser;
using static CriminalDB.Persistence.Utilities.CommandPrompt;
using System;
using System.Collections.Generic;
using System.Text;
using CriminalDB.Persistence.Context;
using CriminalDB.Core.EntityValidator;

namespace CriminalDB.Persistence.Utilities
{
    public class CrimeForm : ICrimeForm
    {

        private IGenericParser _parser;
        private IDateTimeParser _dateParser;
        private IEntityValidator _validator;

        public CrimeForm(IDateTimeParser dateParser, IEntityValidator validator, IGenericParser parser)
        {
            _dateParser = dateParser;
            _validator = validator;
            _parser = parser;
        }
        
        public void AddCrime()
        {
            using (var unitOfWork = new UnitOfWork(new CriminalContext()))
            {
                int amount;
                Crime crime = new Crime();
                List<Criminal> criminals = new List<Criminal>();
                List<Victim> victims = new List<Victim>();
                List<CrimeCriminal> crimeCriminals = new List<CrimeCriminal>();
                List<CrimeVictim> crimeVictims = new List<CrimeVictim>();
                crime = CrimeInfo(crime);
                Console.WriteLine();
                //Adding Crime to UoW
                unitOfWork.Repository<Crime>().Add(crime);
                amount = _parser.ParseValue<int>(int.TryParse, "How many criminals?");
                for (int i = 0; i < amount; i++)
                {
                    Criminal criminal = new Criminal();
                    CrimeCriminal crimeCriminal = new CrimeCriminal();
                    if(QuestionLoop("Is criminal in database? (y/n)"))
                    {
                        int id = _parser.ParseValue<int>(int.TryParse, "Criminal ID: ");
                        criminal = unitOfWork.Repository<Criminal>().Get(id);                       
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Criminal {0}:", i + 1);
                        criminal = Info(criminal);
                        //Adding Criminal to UoW
                        unitOfWork.Repository<Criminal>().Add(criminal);                        
                    }
                    //Connecting Criminal to Crime.
                    crimeCriminal.Criminal = criminal;
                    crimeCriminal.Crime = crime;
                    criminal.Crimes.Add(crimeCriminal);
                    crime.CrimeCriminals.Add(crimeCriminal);
                    //Adding Criminal and CrimeCriminal to list.
                    criminals.Add(criminal);
                    crimeCriminals.Add(crimeCriminal);      
                    //Adding CrimeCriminal to UoW
                    unitOfWork.Repository<CrimeCriminal>().Add(crimeCriminal);      
                }
                amount = _parser.ParseValue<int>(int.TryParse, "How many victims?");
                for (int i = 0; i < amount; i++)
                {
                    Victim victim = new Victim();
                    CrimeVictim crimeVictim = new CrimeVictim();
                    if(QuestionLoop("Is victim in database? (y/n)"))
                    {
                        int id = _parser.ParseValue<int>(int.TryParse, "Victim ID: ");
                        victim = unitOfWork.Repository<Victim>().Get(id);
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Victim {0}:", i + 1);
                        victim = Info(victim);
                        //Adding Victim to UoW
                        unitOfWork.Repository<Victim>().Add(victim);  
                    }
                    //Connecting Victim to Crime.               
                    crimeVictim.Victim = victim;
                    crimeVictim.Crime = crime;
                    victim.Crimes.Add(crimeVictim);
                    crime.CrimeVictims.Add(crimeVictim);
                    //Adding Victim and CrimeVictim to list.
                    victims.Add(victim);
                    crimeVictims.Add(crimeVictim);
                    //Adding CrimeVictim to UoW
                    unitOfWork.Repository<CrimeVictim>().Add(crimeVictim);           
                }
                //Validation before adding!               
                if(ValidateAll(crime, criminals, victims) == false)
                    Console.WriteLine("Error, validation failed!");
                else
                    unitOfWork.Complete();
            }
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        private Crime CrimeInfo(Crime crime)
        {
            crime.Type = Input("Type:");
            crime.Time = _dateParser.Parse("DateTime format (DD-MM-YYYY HH:MM:SS) \nDate and time:");
            crime.Location = Input("Location:");
            crime.Description = Input("Description:");
            return crime;
        }
        
        private TEntity Info<TEntity>(TEntity person) where TEntity : Person
        {
            person.FirstName = Input("First Name:");
            person.LastName = Input("Last Name:");
            person.Nationality = Input("Nationality:");
            person.DateOfBirth = _dateParser.Parse("DateTime format: DD-MM-YYYY \nBirthday date:");
            //Gender
            while (true)
            {
                string _gender = Input("Gender (m/f):");
                if (_gender.StartsWith("m", true, null))
                {
                    person.Gender = "Male";
                    break;
                }
                else if (_gender.StartsWith("f", true, null))
                {
                    person.Gender = "Female";
                    break;
                }
                else
                    Console.WriteLine("Invalid gender!");
            }
            person.Height = _parser.ParseValue<float>(float.TryParse, "Height:");
            person.Weight = _parser.ParseValue<float>(float.TryParse, "Weight:");
            person.Address = Input("Address:");
            person.Photo = Input("Photo:");
            var criminal = person as Criminal;
            if(criminal != null)
                criminal.Description = Input("Description:");
            return person;
        }

        public void Remove<TEntity>() where TEntity : class
        {
            int id = _parser.ParseValue<int>(int.TryParse, "Crime ID:");
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
                if(result.StartsWith("y", true, null))
                    return true;
                else if(result.StartsWith("n", true, null))
                    return false;
                else
                    Console.Write("Invalid option.");
            }
        }

        private bool ValidateAll(Crime crime, List<Criminal> criminals, List<Victim> victims)
        {
            List<bool> validationResults = new List<bool>();
            validationResults.Add(_validator.Validate(crime));
            validationResults.Add(_validator.ValidateDates(crime.Time));
            foreach(var criminal in criminals)
            {
                validationResults.Add(_validator.Validate(criminal));
                validationResults.Add(_validator.ValidateDates(criminal.DateOfBirth, crime.Time));
            }
            foreach(var victim in victims)
            {
                validationResults.Add(_validator.Validate(victim));
                validationResults.Add(_validator.ValidateDates(victim.DateOfBirth, crime.Time));
            }
            if(validationResults.Contains(false))
                return false;
            return true;
        }
    }
}
