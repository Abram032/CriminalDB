using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriminalDB.Core.DataModels
{
    public class Victim : Person
    {
        [Required(ErrorMessage = "Crime is required!"),
        MinLength(1, ErrorMessage = "Victim must have at least 1 crime!")]
        public ICollection<CrimeVictim> Crimes { get; set; } = new List<CrimeVictim>();
    }
}
