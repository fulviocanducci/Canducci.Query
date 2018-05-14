using Canducci.Query.Clauses.Interfaces;
using System.Collections.Generic;
namespace Canducci.Query
{
    internal partial class QueryBuilder
    {
        private string Command { get; set; }
        private List<IClauses> Clauses { get; set; }

        public QueryBuilder(string command)
        {
            Init(command);
        }

        private void Init(string command)
        {
            if (Clauses == null)
            {
                Clauses = new List<IClauses>();
            }
            Command = command;
        }
        
    }
}
