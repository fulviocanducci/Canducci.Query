using Canducci.Query;
using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FactoryQueryBuilder f = new FactoryQueryBuilder();
            
            var insert = f
                .Insert()
                .From("User")
                .Columns("Name", "Created")
                .Values("N1", DateTime.Parse("1999-01-01"))
                .Build();


            var update = f
                .Update()
                .Where("Id", 1).Or("Id", 10, "<>").And("Id", 15)
                .From("User")
                .Columns("Name")
                .Values("N2")
                .Build();
        }
    }
}
