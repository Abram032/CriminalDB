using CriminalDB.Core.DataModels;
using CriminalDB.Core.EntityValidator;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace CriminalDB.Persistence.EntityValidator
{
    public class EntityValidator : IEntityValidator
    {
        public bool Validate<TEntity>(TEntity entity) where TEntity : class
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(entity, null, null);
            var isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);
            foreach(var result in validationResults)
                Console.WriteLine(result.ErrorMessage);
            return isValid;
        }

        public bool ValidateDates(DateTime t1) => DateTime.Compare(t1, DateTime.Now) < 0;
        public bool ValidateDates(DateTime t1, DateTime t2) => DateTime.Compare(t1, t2) < 0;
    }
}