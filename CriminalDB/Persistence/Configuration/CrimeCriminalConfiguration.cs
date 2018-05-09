using CriminalDB.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Configuration
{
    public class CrimeCriminalConfiguration : IEntityTypeConfiguration<CrimeCriminal>
    {
        public void Configure(EntityTypeBuilder<CrimeCriminal> builder)
        {
            builder.HasKey(x => new { x.CrimeID, x.ID });

            builder.HasOne(c => c.Criminal).WithMany(c => c.Crimes).HasForeignKey(c => c.ID);
            builder.HasOne(c => c.Crime).WithMany(c => c.CrimeCriminals).HasForeignKey(c => c.CrimeID);
        }
    }
}
