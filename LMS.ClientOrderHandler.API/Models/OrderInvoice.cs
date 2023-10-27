namespace LMS.ClientOrderHandler.API.Models
{
    public class OrderInvoice
    {
        public int Id { get; set; } 

        public int OrderId { get; set; }

        public int PharmacyId { get; set; }
        public DateTime OrderCompleted { get; set; }

    }
}
