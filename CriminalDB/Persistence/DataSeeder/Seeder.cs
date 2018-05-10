using CriminalDB.Core.DataModels;
using CriminalDB.Persistence.Context;
using static CriminalDB.Persistence.Utilities.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.DataSeeder
{
    public class Seeder
    {
        public void SeedDatabase(int records = 10)
        {
            CrimeSeeder crimeSeeder = new CrimeSeeder();
            PersonSeeder personSeeder = new PersonSeeder();

            for (int i = 0; i < records; i++)
            {
                Console.Clear();
                Console.WriteLine("Seeding database: {0}/{1}", i+1, records);
                using (var unitOfWork = new UnitOfWork(new CriminalContext()))
                {
                    Crime crime = crimeSeeder.GetRandomCrimeSeed();
                    int criminalAmount = GetRandomInt(1, 5);
                    for (int ca = 0; ca < criminalAmount; ca++)
                    {
                        Criminal criminal = personSeeder.GetRandomPersonSeed<Criminal>();
                        criminal.Description = "Random Description";
                        //Adding to fields
                        CrimeCriminal crimeCriminal = new CrimeCriminal();
                        crimeCriminal.Criminal = criminal;
                        crimeCriminal.Crime = crime;
                        criminal.Crimes.Add(crimeCriminal);
                        crime.CrimeCriminals.Add(crimeCriminal);
                        //Adding to databses
                        unitOfWork.Repository<Criminal>().Add(criminal);
                        unitOfWork.Repository<CrimeCriminal>().Add(crimeCriminal);
                    }
                    int victimAmount = GetRandomInt(1, 5);
                    for (int va = 0; va < victimAmount; va++)
                    {
                        Victim victim = personSeeder.GetRandomPersonSeed<Victim>();
                        //Adding to fields
                        CrimeVictim crimeVictim = new CrimeVictim();
                        crimeVictim.Victim = victim;
                        crimeVictim.Crime = crime;
                        victim.Crimes.Add(crimeVictim);
                        crime.CrimeVictims.Add(crimeVictim);
                        //Adding to databse
                        unitOfWork.Repository<Victim>().Add(victim);
                        unitOfWork.Repository<CrimeVictim>().Add(crimeVictim);
                    }
                    unitOfWork.Complete();
                }
            }
        }
    }
}
