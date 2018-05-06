using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriminalDB.Database.Model
{
    public class Victim : Person
    {
        public ICollection<CrimeVictim> Crimes { get; set; }
    }
}
