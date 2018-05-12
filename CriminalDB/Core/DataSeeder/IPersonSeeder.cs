using CriminalDB.Core.DataModels;

namespace CriminalDB.Core.DataSeeder
{
    public interface IPersonSeeder
    {
        TEntity GetRandomPersonSeed<TEntity>() where TEntity : Person, new();
    }
}