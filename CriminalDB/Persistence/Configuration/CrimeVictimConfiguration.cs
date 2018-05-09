using CriminalDB.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Configuration
{
    public class CrimeVictimConfiguration : IEntityTypeConfiguration<CrimeVictim>
    {
        public void Configure(EntityTypeBuilder<CrimeVictim> builder)
        {
            builder.HasKey(x => new { x.CrimeID, x.VictimID });

            builder.HasOne(c => c.Victim).WithMany(c => c.Crimes).HasForeignKey(c => c.VictimID);
            builder.HasOne(c => c.Crime).WithMany(c => c.CrimeVictims).HasForeignKey(c => c.CrimeID);
        }
    }
}
