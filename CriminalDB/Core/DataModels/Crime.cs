using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static CriminalDB.Core.DataModels.Enums;

namespace CriminalDB.Core.DataModels
{
    public class Crime : Entity
    {
        public string Type { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public ICollection<CrimeCriminal> CrimeCriminals { get; set; } = new List<CrimeCriminal>();
        public ICollection<CrimeVictim> CrimeVictims { get; set; } = new List<CrimeVictim>();
    }
}
