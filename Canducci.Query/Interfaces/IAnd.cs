namespace Canducci.Query.Interfaces
{
    public interface IAnd
    {
        IAnd And(string name, object value, string comparation = "=");
        IColumns From(string table);
    }
}
