using CriminalDB.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Core.Repository
{
    public interface ICriminalRepository : IGenericRepository<Criminal>
    {
        Criminal GetCriminalWithCrimes(int id);
        IEnumerable<Criminal> GetCriminalsWithCrimes();
    }
}
