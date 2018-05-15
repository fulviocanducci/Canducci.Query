using Canducci.Query.Interfaces;
using Dapper;
using Microsoft.Data.Sqlite;
namespace ConsoleTest.Models
{
    public class Connection
    {
        public Connection()
        {
            Connect();
        }
        internal SqliteConnection Database;
        internal void Connect()
        {
            try
            {
                string path = System.Environment.CurrentDirectory.Replace("bin\\Debug\\netcoreapp2.0","");
                Database = new SqliteConnection($"Data Source={path}Sample.db;");
            }
            catch (SqliteException ex)
            {
                throw ex;
            }            
        }

        public int Insert(IResultCommand command)
        {
            return Database.Execute(command.SqlRaw, command.Parameters);
        }

        public int Update(IResultCommand command)
        {
            return Database.Execute(command.SqlRaw, command.Parameters);
        }
    }
}
