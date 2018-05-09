using CriminalDB.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Configuration
{
    public class VictimConfiguration : PersonConfiguration<Victim>
    {
        public override void Configure(EntityTypeBuilder<Victim> builder)
        {
            base.Configure(builder);
        }
    }
}
