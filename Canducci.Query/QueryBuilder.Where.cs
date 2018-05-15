using Canducci.Query.Clauses;
using Canducci.Query.Interfaces;

namespace Canducci.Query
{
    internal partial class QueryBuilder : IWhere, IAnd, IOr
    {
        public IAnd And(string name, object value, string comparation = "=")
        {
            Clauses.Add(WhereClause.Create(new { Name = name, Value = value, Comparation = comparation, TypeLogical = "AND" }));
            return this;
        }
        
        public IOr Or(string name, object value, string comparation = "=")
        {
            Clauses.Add(WhereClause.Create(new { Name = name, Value = value, Comparation = comparation, TypeLogical = "OR" }));
            return this;
        }

        public IAnd Where(string name, object value, string comparation = "=")
        {
            return And(name, value, comparation);
        }

        public IAnd AndNull(string name)
        {
            return WhereNull(name);
        }
        
        public IOr OrNull(string name)
        {
            Clauses.Add(WhereClause.Create(new { Name = name, Comparation = "ISNULL", TypeLogical = "OR" }));
            return this;
        }        

        public IAnd WhereNull(string name)
        {
            Clauses.Add(WhereClause.Create(new { Name = name, Comparation = "ISNULL", TypeLogical = "AND" }));
            return this;
        }

        public IAnd WhereBetween<TTo, TFrom>(string name, TTo initial, TFrom end)
        {
            Clauses.Add(WhereClause.Create(new { Name = name, Initial = initial, End = end, Comparation = "BETWEEN", TypeLogical = "AND" }));
            return this;
        }

        public IOr OrWhereBetween<TTo, TFrom>(string name, TTo initial, TFrom end)
        {
            Clauses.Add(WhereClause.Create(new { Name = name, Initial = initial, End = end, Comparation = "BETWEEN", TypeLogical = "OR" }));
            return this;
        }

        public IAnd AndWhereBetween<TTo, TFrom>(string name, TTo initial, TFrom end)
        {
            return WhereBetween(name, initial, end);
        }

        public IAnd WhereIn(string name, params object[] values)
        {
            Clauses.Add(WhereClause.Create(new { Name = name, Values = values, Comparation = "IN", TypeLogical = "AND" }));
            return this;
        }

        public IAnd AndWhereIn(string name, params object[] values)
        {
            return WhereIn(name, values);
        }

        public IOr OrWhereIn(string name, params object[] values)
        {
            Clauses.Add(WhereClause.Create(new { Name = name, Values = values, Comparation = "IN", TypeLogical = "AND" }));
            return this;
        }
    }
}
