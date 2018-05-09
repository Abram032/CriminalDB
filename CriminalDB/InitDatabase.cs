using CriminalDB.Persistence.Context;
using CriminalDB.Persistence.DataSeeder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB
{
    public class InitDatabase
    {
        public void Main()
        {
            using (var context = new CriminalContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
                //context.Database.EnsureCreated();
            }

            Seeder seeder = new Seeder();
            seeder.SeedDatabase();
        }
    }
}