namespace Canducci.Query.Interfaces
{
    public interface IOr
    {
        IOr Or(string name, object value, string comparation = "=");
        IAnd And(string name, object value, string compartion = "=");
        IColumns From(string table);
    }
}
