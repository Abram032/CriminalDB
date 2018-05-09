using CriminalDB.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Configuration
{
    public class CrimeConfiguration : IEntityTypeConfiguration<Crime>
    {
        public void Configure(EntityTypeBuilder<Crime> builder)
        {
            builder.HasKey(x => x.CrimeID);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Time).IsRequired().HasColumnType("DateTime");
            builder.Property(x => x.Location).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            builder.Property(x => x.CrimeCriminals).IsRequired();
        }
    }
}
