namespace LMS.OrderService.API.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        
    }
}
