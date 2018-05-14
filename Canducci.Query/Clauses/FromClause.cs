using Canducci.Query.Clauses.Interfaces;
namespace Canducci.Query.Clauses
{
    public class FromClause : IFromClause
    {
        public string Name { get; }
        public object Value { get; }

        public FromClause(object value)
        {
            Name = "From";
            Value = value;
        }       

        public static IFromClause Create(object value)
            => new FromClause(value);
    }
}
