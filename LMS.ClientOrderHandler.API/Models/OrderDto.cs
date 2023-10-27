using System.ComponentModel.DataAnnotations;

namespace LMS.ClientOrderHandler.API.Models
{
    public class OrderDto
    {
     
        public OrderServiceModel CustomerOrder { get; set; }
        
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
