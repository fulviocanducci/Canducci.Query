using Canducci.Query.Clauses;
using Canducci.Query.Interfaces;
using System;

namespace Canducci.Query
{
    internal partial class QueryBuilder : IColumns
    {
        public IValues Columns(params object[] columns)
        {
            Clauses.Add(ColumnsClause.Create(columns));
            return this;
        }
    }
}
