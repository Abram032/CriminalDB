using CriminalDB.Core.DataSeeder;
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
        private ISeeder _seeder;
        int _amount;

        public InitDatabase(ISeeder seeder, int amount)
        {
            _seeder = seeder;
            _amount = amount;
        }
        public void Main()
        {
            using (var context = new CriminalContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();
                //context.Database.EnsureCreated();
            }

            _seeder.SeedDatabase(_amount);
        }
    }
}