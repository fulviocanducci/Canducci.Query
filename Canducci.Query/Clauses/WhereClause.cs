using Canducci.Query.Clauses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Canducci.Query.Clauses
{
    public class WhereClause : IWhereClause
    {
        public string Name { get; }
        public object Value { get; }

        public WhereClause(object value)
        {
            Name = "Where";
            Value = value;
        }

        public static IWhereClause Create(object value)
        {
            return new WhereClause(value);
        }
    }
}
