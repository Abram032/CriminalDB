using CriminalDB.Core.DataModels;
using CriminalDB.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Repository
{
    public class CrimeVictimRepository : Repository<CrimeVictim>, ICrimeVictimRepository
    {
        public CrimeVictimRepository(DbContext context) : base(context)
        {

        }
    }
}
