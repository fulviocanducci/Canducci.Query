namespace Canducci.Query.Interfaces
{
    public interface IWhere
    {        
        IAnd Where(string name, object value, string comparation = "=");
        IAnd WhereNull(string name);
        IAnd WhereBetween<TTo, TFrom>(string name, TTo initial, TFrom end);
        IAnd WhereIn(string name, params object[] values);
    }
}
