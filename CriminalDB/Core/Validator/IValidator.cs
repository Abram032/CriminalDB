using CriminalDB.Core.DataModels;

namespace CriminalDB.Core.Validator
{
    public interface IValidator
    {
         bool ValidatePerson(Crime entity);
         bool ValidatePerson<TEntity>(TEntity entity) where TEntity : Person;
    }
}