namespace Canducci.Query.Interfaces
{
    public interface IOr
    {
        IOr Or(string name, object value, string comparation = "=");
        IAnd And(string name, object value, string compartion = "=");

        IColumns From(string table);

        IAnd AndNull(string name);
        IOr OrNull(string name);        

        IAnd AndWhereBetween<TTo, TFrom>(string name, TTo initial, TFrom end);
        IOr OrWhereBetween<TTo, TFrom>(string name, TTo initial, TFrom end);        

        IAnd AndWhereIn(string name, params object[] values);
        IOr OrWhereIn(string name, params object[] values);
    }
}

