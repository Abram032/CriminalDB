using CriminalDB.Core.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Core.Utilities
{
    public interface IViewForm
    {
        void Crime(bool showCriminals = false, bool showVictims = false);
        void AllCrimes(bool showCriminals = false, bool showVictims = false);

        void Person<TEntity>(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false) where TEntity : Person;
        void AllPeople<TEntity>(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false) where TEntity : Person;
    }
}
