using Microsoft.EntityFrameworkCore;
using CriminalDB.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

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
            modelBuilder.Entity<CrimeCriminal>().HasKey(x => new { x.CrimeID, x.ID });
            modelBuilder.Entity<CrimeVictim>().HasKey(x => new { x.CrimeID, x.ID });

            modelBuilder.Entity<CrimeCriminal>().HasOne(c => c.Criminal).WithMany(c => c.Crimes).HasForeignKey(c => c.ID);
            modelBuilder.Entity<CrimeCriminal>().HasOne(c => c.Crime).WithMany(c => c.CrimeCriminals).HasForeignKey(c => c.CrimeID);
            modelBuilder.Entity<CrimeVictim>().HasOne(c => c.Victim).WithMany(c => c.Crimes).HasForeignKey(c => c.ID);
            modelBuilder.Entity<CrimeVictim>().HasOne(c => c.Crime).WithMany(c => c.CrimeVictims).HasForeignKey(c => c.CrimeID);
        }
    }
}
