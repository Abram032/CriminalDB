using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriminalDB.Core.DataModels
{
    public class Victim : Person
    {
        public ICollection<CrimeVictim> Crimes { get; set; } = new List<CrimeVictim>();
    }
}
