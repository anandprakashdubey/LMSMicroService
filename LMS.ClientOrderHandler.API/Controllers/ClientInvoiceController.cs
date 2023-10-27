using LMS.ClientOrderHandler.API.Models;
using LMS.ClientOrderHandler.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.ClientOrderHandler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientInvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _repository;
        private readonly IOrderProcessorRepository _orderRepo;
        
        public ClientInvoiceController(IInvoiceRepository repository, IOrderProcessorRepository orderRepo)
        {
            _repository = repository;
            _orderRepo = orderRepo;
        }

        [HttpPost("generateinvoice")]
        public async Task<OrderInvoice> CreateInvoice(OrderInvoice invoice, string status)
        {
            
           var isProcessed = await _orderRepo.ProcessOrder(invoice.OrderId, status);

            if (!isProcessed)
            {
                return await _repository.CreateInvoice(invoice);
            }
            else
                return null;
        }
    }
}
