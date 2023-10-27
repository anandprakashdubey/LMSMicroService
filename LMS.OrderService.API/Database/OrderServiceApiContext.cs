using LMS.OrderService.API.Models;
using MongoFramework;

namespace LMS.OrderService.API.Database
{
    public class OrderServiceApiContext: MongoDbContext
    {
        public OrderServiceApiContext(IMongoDbConnection connection) : base(connection)
        {
        }

        public MongoDbSet<OrderServiceModel> Orders { get; set; }
        public MongoDbSet<OrderItem> OrderItems { get; set; }
    }
}
