using Canducci.Query;
using ConsoleTest.Models;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection();

            FactoryQueryBuilder f = new FactoryQueryBuilder();

            //var insert = f
            //    .Insert()
            //    .From("user")
            //    .Columns("name", "created", "status")
            //    .Values("Paulo", Parameter.NullValue<DateTime>(), false)
            //    .Build();

            //connection.Insert(insert);

            var update = f
                .Update()
                .WhereIn("Status", 1, 0)
                .From("User")
                .Columns("created")
                .Values(DateTime.Parse("10/07/2015"))
                .Build();

            connection.Update(update);
        }
    }
}
