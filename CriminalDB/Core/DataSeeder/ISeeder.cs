namespace CriminalDB.Core.DataSeeder
{
    public interface ISeeder
    {
        void SeedDatabase(int records = 10);
    }
}