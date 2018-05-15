namespace Canducci.Query.Interfaces
{
    public interface IResultCommand
    {
        string SqlRaw { get; }
        object Parameters { get; }
    }
}
