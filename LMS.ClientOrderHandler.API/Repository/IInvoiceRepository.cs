using LMS.ClientOrderHandler.API.Models;

namespace LMS.ClientOrderHandler.API.Repository
{
    public interface IInvoiceRepository
    {
        public Task<OrderInvoice> CreateInvoice(OrderInvoice invoice);
    }
}
