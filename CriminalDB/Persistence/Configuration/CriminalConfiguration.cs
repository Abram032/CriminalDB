using CriminalDB.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Configuration
{
    public class CriminalConfiguration : PersonConfiguration
    {
        public CriminalConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Criminal> builder)
        {
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        }
    }
}
