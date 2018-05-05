using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static CriminalDB.Database.Model.Enums;

namespace CriminalDB.Database.Model
{
    public class Crime
    {
        [Key]
        public int CrimeID { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [MinLength(1)]
        public ICollection<Criminal> Criminals { get; set; }
        public ICollection<Victim> Victims { get; set; }
    }
}
