using CriminalDB.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Configuration
{
    public class VictimConfiguration : PersonConfiguration
    {
        public VictimConfiguration() : base()
        {

        }

        public void Configure(EntityTypeBuilder<Victim> builder)
        {
            
        }
    }
}
