namespace CriminalDB.Core.Utilities
{
    public delegate bool TryParseHandler<T>(string value, out T result);

    public interface IGenericParser
    {
        T ParseValue<T>(TryParseHandler<T> handler, string message = "") where T : struct;
    }
}