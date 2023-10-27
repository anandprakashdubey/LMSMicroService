namespace LMS.OrderService.API.Models
{
    public class OrderServiceModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PharmacyId { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public string PaymentType { get; set; }
        public string FinalAmount { get; set; }
        public string OrderStatus { get; set; }
    }
}
