using CriminalDB.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Configuration
{
    public class CrimeConfiguration : EntityConfiguration<Crime>
    {
        public override void Configure(EntityTypeBuilder<Crime> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Time).IsRequired().HasColumnType("DateTime");
            builder.Property(x => x.Location).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            builder.HasMany(x => x.CrimeCriminals).WithOne(x => x.Crime).HasForeignKey(x => x.CriminalID).IsRequired();
            builder.HasMany(x => x.CrimeVictims).WithOne(x => x.Crime).HasForeignKey(x => x.VictimID);
        }
    }
}
