using CriminalDB.Core.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Configuration
{
    public abstract class PersonConfiguration<TEntity> : EntityConfiguration<TEntity> where TEntity : Person
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Nationality).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DateOfBirth).IsRequired().HasColumnType("Date");
            builder.Property(x => x.Height).IsRequired().HasColumnType("Float");
            builder.Property(x => x.Weight).IsRequired().HasColumnType("Float");
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Photo).IsRequired().HasMaxLength(250);
        }
    }
}
