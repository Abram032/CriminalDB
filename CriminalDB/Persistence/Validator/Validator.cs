using CriminalDB.Core.DataModels;
using CriminalDB.Core.Validator;

namespace CriminalDB.Persistence.Validator
{
    public class Validator : IValidator
    {
        public bool ValidatePerson(Crime entity)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidatePerson<TEntity>(TEntity entity) where TEntity : Person
        {
            throw new System.NotImplementedException();
        }
    }
}