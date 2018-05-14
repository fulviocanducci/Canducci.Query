namespace Canducci.Query.Interfaces
{
    public interface IColumns
    {
        IValues Columns(params object[] columns);
    }
}
