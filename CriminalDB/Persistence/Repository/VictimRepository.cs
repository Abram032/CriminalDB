using CriminalDB.Core.DataModels;
using CriminalDB.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CriminalDB.Persistence.Context;

namespace CriminalDB.Persistence.Repository
{
    public class VictimRepository : GenericRepository<Victim>, IVictimRepository
    {
        public VictimRepository(DbContext context) : base(context)
        {
            
        }

        public CriminalContext CriminalContext
        {
            get { return _context as CriminalContext; }
        }

        public Victim GetVictimWithCrimes(int id)
        {
            return CriminalContext.Victims
            .Include(x => x.Crimes)
            .ThenInclude(x => x.Crime)
            .Where(x => x.ID == id)
            .SingleOrDefault();
        }

        public IEnumerable<Victim> GetVictimsWithCrimes()
        {
            return CriminalContext.Victims
            .Include(x => x.Crimes)
            .ThenInclude(x => x.Crime)
            .OrderBy(x => x.ID)
            .ToList();
        }
    }
}
