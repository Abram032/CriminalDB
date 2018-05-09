using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Core.DataModels
{
    public class CrimeVictim
    {
        public int CrimeID { get; set; }
        public Crime Crime { get; set; }

        public int VictimID { get; set; }
        public Victim Victim { get; set; }
    }
}
