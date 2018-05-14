using Canducci.Query.Interfaces;

namespace Canducci.Query
{
    public sealed class ResultCommand : IResultCommand
    {
        public string Raw { get; }

        public object Parameters { get; }

        public ResultCommand(string raw, object parameters = null)
        {
            Raw = raw;
            Parameters = parameters;
        }        
    }
}
