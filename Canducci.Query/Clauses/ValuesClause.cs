using Canducci.Query.Clauses.Interfaces;
namespace Canducci.Query.Clauses
{
    public class ValuesClause : IValuesClause
    {
        public string Name { get; }
        public object Value { get; }

        public ValuesClause(object value)
        {
            Name = "Values";
            Value = value;
        }

        public static IValuesClause Create(object value)
        {
            return new ValuesClause(value);
        }
    }
}
