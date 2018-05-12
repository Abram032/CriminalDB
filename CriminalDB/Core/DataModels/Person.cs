using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CriminalDB.Core.DataModels
{
    public abstract class Person : Entity
    {
        [Required(ErrorMessage = "First name is required!"), 
        MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters."), 
        RegularExpression("^[A-z]+", ErrorMessage = "Name can only contain letters.")]
         public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!"), 
        MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters."), 
        RegularExpression("^[A-z]+", ErrorMessage = "Name can only contain letters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Gender required!"),  
        RegularExpression("[Ff]?e?[Mm]ale", ErrorMessage = "Gender has to be either Male of Female")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Nationality is required!"),
        MaxLength(50, ErrorMessage = "Nationality can't be longer than 50 characters."),
        RegularExpression("^[A-z]+", ErrorMessage = "Nationality can only contain letters.")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Date of birth is required!"), DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Height is required!"), Range(1f, 300f, ErrorMessage = "Height must be between 0 and 300.")]
        public float Height { get; set; }

        [Required(ErrorMessage = "Weight is required!"), Range(1f, 600f, ErrorMessage = "Weight must be between 0 and 600.")]
        public float Weight { get; set; }

        [Required(ErrorMessage = "Address is required!"), 
        MaxLength(100, ErrorMessage = "Address can't be longer than 100 characters"), 
        MinLength(1, ErrorMessage = "Address can't be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Photo is required!"), 
        MaxLength(250, ErrorMessage = "Address can't be longer than 250 characters"), 
        MinLength(1, ErrorMessage = "Address can't be empty")]
        public string Photo { get; set; }
    }
}
