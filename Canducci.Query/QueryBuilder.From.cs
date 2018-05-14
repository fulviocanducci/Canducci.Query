using Canducci.Query.Clauses;
using Canducci.Query.Interfaces;

namespace Canducci.Query
{
    internal partial class QueryBuilder : IFrom
    {
        public IColumns From(string table)
        {
            Clauses.Add(FromClause.Create(table));
            return this;
        }
    }
}
