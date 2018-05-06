using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Database.Model
{
    public class CriminalContext : DbContext
    {
        public DbSet<Criminal> Criminals { get; set; }
        public DbSet<Victim> Victims { get; set; }
        public DbSet<Crime> Crimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Crimes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrimeCriminal>().HasKey(x => new { x.CrimeID, x.ID });
            modelBuilder.Entity<CrimeVictim>().HasKey(x => new { x.CrimeID, x.ID });
        }
    }
}
