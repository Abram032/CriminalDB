using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriminalDB.Core.DataModels
{
    public class Criminal : Person
    {
        public string Description { get; set; }

        public ICollection<CrimeCriminal> Crimes { get; set; } = new List<CrimeCriminal>();
    }
}
