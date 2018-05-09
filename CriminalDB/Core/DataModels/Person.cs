using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static CriminalDB.Core.DataModels.Enums;

namespace CriminalDB.Core.DataModels
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
    }
}
