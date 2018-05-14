using Canducci.Query.Clauses.Interfaces;

namespace Canducci.Query.Clauses
{
    public class ColumnsClause : IColumnsClause
    {
        public string Name { get; }
        public object Value { get; }

        public ColumnsClause(object value)
        {
            Name = "Columns";
            Value = value;
        }       

        public static IColumnsClause Create(object value)
        {
            return new ColumnsClause(value);
        }
    }
}
