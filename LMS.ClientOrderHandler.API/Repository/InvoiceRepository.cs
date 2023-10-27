using LMS.ClientOrderHandler.API.Database;
using LMS.ClientOrderHandler.API.Models;

namespace LMS.ClientOrderHandler.API.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ClientOrderHandlerApiContext _context;
        public InvoiceRepository(ClientOrderHandlerApiContext context)
        {
            _context = context;
        }
        public async Task<OrderInvoice> CreateInvoice(OrderInvoice invoice)
        {
             _context.Invoice.Add(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }
    }
}
