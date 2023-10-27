using LMS.ClientOrderHandler.API.Models;
using MongoFramework;

namespace LMS.ClientOrderHandler.API.Database
{
    public class ClientOrderHandlerApiContext : MongoDbContext
    {
        public ClientOrderHandlerApiContext(IMongoDbConnection connection) : base(connection)
        {
        }

        public MongoDbSet<OrderInvoice> Invoice { get; set; }
    }
}
