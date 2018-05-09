using Microsoft.EntityFrameworkCore;
using CriminalDB.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using CriminalDB.Persistence.Configuration;

namespace CriminalDB.Persistence.Context
{
    public class CriminalContext : DbContext
    {
        public DbSet<Criminal> Criminals { get; set; }
        public DbSet<Victim> Victims { get; set; }
        public DbSet<Crime> Crimes { get; set; }
        public DbSet<CrimeCriminal> CrimeCriminals { get; set; }
        public DbSet<CrimeVictim> CrimeVictims { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Crimes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CrimeConfiguration());
            modelBuilder.ApplyConfiguration(new CrimeCriminalConfiguration());
            modelBuilder.ApplyConfiguration(new CrimeVictimConfiguration());
            modelBuilder.ApplyConfiguration(new CriminalConfiguration());
            modelBuilder.ApplyConfiguration(new VictimConfiguration());
        }
    }
}
