using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Core.Utilities
{
    public interface IViewForm
    {
        void Crime(bool showCriminals = false, bool showVictims = false);
        void AllCrimes(bool showCriminals = false, bool showVictims = false);

        void Criminal(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false);
        void AllCriminals(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false);

        void Victim(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false);
        void AllVictims(bool showDetails = false, bool showCrimes = false, bool showCrimesDetails = false);
    }
}
