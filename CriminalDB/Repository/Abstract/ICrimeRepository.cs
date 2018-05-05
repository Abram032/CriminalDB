using CriminalDB.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Repository.Abstract
{
    public interface ICrimeRepository : IRepository<Crime>
    {
        IEnumerable<Crime> GetCrimes();
        IEnumerable<Crime> GetCrimesWithCriminals();
        IEnumerable<Crime> GetCrimesWithCriminalsAndVictims();
        Crime GetCrimeWithCriminals(int id);
        Crime GetCrimeWithCriminalsAndVictims(int id);
    }
}
