using CriminalDB.Core.DataModels;

namespace CriminalDB.Core.DataSeeder
{
    public interface ICrimeSeeder
    {
        Crime GetRandomCrimeSeed();
    }
}