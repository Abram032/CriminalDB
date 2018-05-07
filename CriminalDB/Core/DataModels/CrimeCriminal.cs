using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Core.DataModels
{
    public class CrimeCriminal
    {
        public int CrimeID { get; set; }
        public Crime Crime { get; set; }

        public int ID { get; set; }
        public Criminal Criminal { get; set; }
    }
}
