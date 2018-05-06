using System;
using System.Collections.Generic;
using System.Text;

namespace CriminalDB.Database.Model
{
    public class CrimeCriminal
    {
        public int CrimeID { get; set; }
        public Crime Crime { get; set; }

        public int ID { get; set; }
        public Criminal Criminal { get; set; }
    }
}
