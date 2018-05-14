namespace Canducci.Query.Interfaces
{
    public interface IValues
    {
        ICommand Values(params object[] values);
    }
}
