using Canducci.Query.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Canducci.Query.Utils.ParameterObjectBuilder;
namespace Canducci.Query
{
    internal partial class QueryBuilder : ICommand
    {
        public IResultCommand Build()
        {
            StringBuilder sql = new StringBuilder();
            sql.Clear();
            var columns = (object[])Clauses.Where(x => x.Name == "Columns").FirstOrDefault().Value;
            var values = (object[])Clauses.Where(x => x.Name == "Values").FirstOrDefault().Value;
            var wheres = (object[])Clauses.Where(x => x.Name == "Where").ToArray();
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            int i = 0;
            string p = string.Empty;
            switch (Command)
            {
                case "Insert":
                    {                        
                        sql.AppendFormat("INSERT INTO {0}", Clauses.Where(x => x.Name == "From").Select(x => x.Value).FirstOrDefault());
                        sql.AppendFormat("({0})", string.Join(",", columns));
                        sql.Append(" VALUES(");                        
                        while (i < columns.Length)
                        {
                            if (i > 0) sql.Append(", ");
                            p = $"@p{i}";
                            sql.Append(p);
                            dictionary.Add(p, values.GetValue(i));
                            i++;
                        }
                        sql.Append(")");
                        break;
                    }
                case "Update":
                    {
                        sql.AppendFormat("UPDATE {0} SET ", Clauses.Where(x => x.Name == "From").Select(x => x.Value).FirstOrDefault());
                        while (i < columns.Length)
                        {
                            if (i > 0) sql.Append(", ");
                            p = $"@p{i}";
                            sql.Append($"{columns.GetValue(i)}={p}");
                            dictionary.Add(p, values.GetValue(i));
                            i++;
                            
                        }
                        if (wheres != null)
                        {                            
                            int j = 0;
                            while (j < wheres.Length)
                            {
                                dynamic where = (dynamic)wheres.GetValue(j);
                                if (j == 0) sql.Append(" WHERE");
                                if (j > 0) sql.Append(" AND");                                
                                p = $"@p{i}";
                                sql.Append($" {where.Value.Name}{where.Value.Comparation}{p}");
                                dictionary.Add(p, where.Value.Value);
                                i++;
                                j++;
                            }
                        }
                        break;
                    }
            }
            return new ResultCommand(sql.ToString(), CreateObjectWithValues(dictionary));
        }
    }
}
