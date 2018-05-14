using Canducci.Query.Interfaces;
namespace Canducci.Query
{
    public class FactoryQueryBuilder
    {     
        public IFrom Insert()
        {
            return new QueryBuilder("Insert");
        }

        public IWhere Update()
        {
            return new QueryBuilder("Update");
        }
    }
}
