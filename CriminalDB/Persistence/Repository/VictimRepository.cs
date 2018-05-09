using CriminalDB.Core.DataModels;
using CriminalDB.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Repository
{
    public class VictimRepository : GenericRepository<Victim>, IVictimRepository
    {
        public VictimRepository(DbContext context) : base(context)
        {

        }
    }
}
