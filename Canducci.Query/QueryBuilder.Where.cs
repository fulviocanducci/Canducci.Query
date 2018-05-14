using Canducci.Query.Clauses;
using Canducci.Query.Interfaces;

namespace Canducci.Query
{
    internal partial class QueryBuilder : IWhere, IAnd
    {
        public IAnd And(string name, object value, string comparation = "=")
        {
            Clauses.Add(WhereClause.Create(new { Name = name, Value = value, Comparation = comparation }));
            return this;
        }

        public IAnd Where(string name, object value, string comparation = "=")
        {
            return And(name, value, comparation);
        }
    }
}
