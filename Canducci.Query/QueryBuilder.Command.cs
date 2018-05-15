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
            var from = Clauses.Where(x => x.Name == "From").Select(x => x.Value).FirstOrDefault();
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
                        sql.AppendFormat("INSERT INTO {0}", from);
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
                        sql.AppendFormat("UPDATE {0} SET ", from);
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
                                if (j > 0) sql.Append($" {where.Value.TypeLogical}");
                                if (where.Value.Comparation == "IN")
                                {
                                    sql.Append($" {where.Value.Name} IN(");
                                    byte s = 0;
                                    foreach (var value in where.Value.Values)
                                    {
                                        p = $"@p{i++}";
                                        if (s == 1) sql.Append(",");
                                        sql.Append($"{p}");
                                        dictionary.Add(p, value);
                                        s = 1;
                                    }                                    
                                    sql.Append(")");
                                }
                                else if (where.Value.Comparation == "BETWEEN")
                                {
                                    p = $"@p{i}";
                                    sql.Append($" {where.Value.Name} BETWEEN {p} AND ");
                                    dictionary.Add(p, where.Value.Initial);
                                    p = $"@p{++i}";
                                    sql.Append($"{p}");
                                    dictionary.Add(p, where.Value.End);
                                }
                                else if (where.Value.Comparation == "ISNULL")
                                {
                                    sql.Append($" {where.Value.Name} IS NULL");
                                }
                                else
                                {
                                    p = $"@p{i}";
                                    sql.Append($" {where.Value.Name} {where.Value.Comparation} {p}");
                                    dictionary.Add(p, where.Value.Value);
                                }
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
