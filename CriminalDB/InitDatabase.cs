using CriminalDB.Persistence.Context;
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
                context.Database.EnsureCreated();
            }
        }
    }
}