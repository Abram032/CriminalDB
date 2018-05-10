using CriminalDB.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Core.Repository
{
    public interface ICrimeRepository : IGenericRepository<Crime>
    {
        //IEnumerable<Crime> GetCrimes();
        IEnumerable<Crime> GetCrimesWithCriminals();
        IEnumerable<Crime> GetCrimesWithCriminalsAndVictims();
        Crime GetCrimeWithCriminals(int id);
        Crime GetCrimeWithCriminalsAndVictims(int id);
    }
}
