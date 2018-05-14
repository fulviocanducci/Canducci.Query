using Canducci.Query.Clauses;
using Canducci.Query.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canducci.Query
{
    internal partial class QueryBuilder : IValues
    {
        public ICommand Values(params object[] values)
        {
            Clauses.Add(ValuesClause.Create(values));
            return this;
        }
    }
}
