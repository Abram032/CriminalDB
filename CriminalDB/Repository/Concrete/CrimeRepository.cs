using CriminalDB.Database.Model;
using CriminalDB.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Repository.Concrete
{
    public class CrimeRepository : Repository<Crime>, ICrimeRepository
    {
        public CrimeRepository(DbContext context) : base(context)
        {

        }

        public CriminalContext CriminalContext
        {
            get { return _context as CriminalContext; }
        }

        public Crime GetCrimeWithCriminals(int id)
        {
            return CriminalContext.Crimes
                .Include(x => x.CrimeCriminals)
                .ThenInclude(x => x.Criminal)
                .Where(x => x.CrimeID == id)
                .SingleOrDefault();
        }

        public Crime GetCrimeWithCriminalsAndVictims(int id)
        {
            return CriminalContext.Crimes
                .Include(x => x.CrimeCriminals)
                .ThenInclude(x => x.Criminal)
                .Include(x => x.CrimeVictims)
                .ThenInclude(x => x.Victim)
                .Where(x => x.CrimeID == id)
                .SingleOrDefault();
        }

        public IEnumerable<Crime> GetCrimes()
        {
            return CriminalContext.Crimes.OrderByDescending(x => x.CrimeID).ToList();
        }

        public IEnumerable<Crime> GetCrimesWithCriminals()
        {
            return CriminalContext.Crimes.
                Include(x => x.CrimeCriminals)
                .ThenInclude(x => x.Criminal)
                .OrderBy(x => x.CrimeID)
                .ToList();
        }

        public IEnumerable<Crime> GetCrimesWithCriminalsAndVictims()
        {
            return CriminalContext.Crimes
                .Include(x => x.CrimeCriminals)
                .ThenInclude(x => x.Criminal)
                .Include(x => x.CrimeVictims)
                .ThenInclude(x => x.Victim)
                .OrderBy(x => x.CrimeID)
                .ToList();
        }
    }
}
