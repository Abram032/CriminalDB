using CriminalDB.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Core.Repository
{
    public interface IVictimRepository : IGenericRepository<Victim>
    {
        Victim GetVictimWithCrimes(int id);
        IEnumerable<Victim> GetVictimsWithCrimes();
    }
}
