using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriminalDB.Core.DataModels
{
    public class Crime : Entity
    {
        [Required(ErrorMessage = "Type is required!")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Date and time is required"), DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Location is required!"), 
        MinLength(1, ErrorMessage = "Location can't be empty!"),
        MaxLength(100, ErrorMessage = "Location can't have more than 100 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Description is required!"),
        MinLength(1, ErrorMessage = "Description can't be empty!"),
        MaxLength(500, ErrorMessage = "Description can't have more than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Criminal is required!"),
        MinLength(1, ErrorMessage = "Crime must have at least one Criminal!")]
        public ICollection<CrimeCriminal> CrimeCriminals { get; set; } = new List<CrimeCriminal>();

        public ICollection<CrimeVictim> CrimeVictims { get; set; } = new List<CrimeVictim>();
    }
}
