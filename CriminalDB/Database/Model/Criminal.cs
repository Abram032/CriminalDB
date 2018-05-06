using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriminalDB.Database.Model
{
    public class Criminal : Person
    {   
        [StringLength(250)]
        public string Description { get; set; }

        public ICollection<CrimeCriminal> Crimes { get; set; } = new List<CrimeCriminal>();
    }
}
