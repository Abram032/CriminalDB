using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriminalDB.Core.DataModels
{
    public class Criminal : Person
    {
        [Required(ErrorMessage = "Description is required!"), 
        MinLength(1, ErrorMessage = "Description can't be empty"), 
        MaxLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Crime is required!"),
        MinLength(1, ErrorMessage = "Criminal must have at least 1 crime!")]
        public ICollection<CrimeCriminal> Crimes { get; set; } = new List<CrimeCriminal>();
    }
}
