using CriminalDB.Core.DataModels;
using CriminalDB.Core.Repository;
using CriminalDB.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Persistence.Repository
{
    public class CriminalRepository: GenericRepository<Criminal>, ICriminalRepository
    {
        public CriminalRepository(DbContext context) : base(context)
        {

        }

        public CriminalContext CriminalContext
        {
            get { return _context as CriminalContext; }
        }

        public Criminal GetCriminalWithCrimes(int id)
        {
            return CriminalContext.Criminals
            .Include(x => x.Crimes)
            .ThenInclude(x => x.Crime)
            .Where(x => x.ID == id)
            .SingleOrDefault();
        }

        public IEnumerable<Criminal> GetCriminalsWithCrimes()
        {
            return CriminalContext.Criminals
            .Include(x => x.Crimes)
            .ThenInclude(x => x.Crime)
            .OrderBy(x => x.ID)
            .ToList();
        }
    }
}
