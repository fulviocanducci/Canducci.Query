using Canducci.Query.Interfaces;

namespace Canducci.Query
{
    public sealed class ResultCommand : IResultCommand
    {
        public string SqlRaw { get; }

        public object Parameters { get; }

        internal ResultCommand(string sqlRaw, object parameters = null)
        {
            SqlRaw = sqlRaw;
            Parameters = parameters;
        }        
    }
}
