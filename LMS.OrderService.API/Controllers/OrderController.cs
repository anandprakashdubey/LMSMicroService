using LMS.OrderService.API.Models;
using LMS.OrderService.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.OrderService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceRepository _repository;
        public OrderController(IOrderServiceRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("createorder")]
        public async Task<OrderDto> CreateOrder(OrderDto dto)
        {
            return await _repository.CreateOrder(dto);
        }

        [HttpGet("orders")]
        public async Task<IEnumerable<OrderServiceModel>> GetAllOrders()
        {
            return await _repository.GetAllOrders();
        }

        [HttpGet("orderitembyid")]
        public async Task<IEnumerable<OrderItem>> GetAllOrderItemByOrderId(int id)
        {
            return await _repository.GetAllOrderItemByOrderId(id);
        }

        [HttpPost("updateorderstatus")]
        public async Task<bool> UpdateOrderStatus(int id, string status)
        {
           return await _repository.UpdateOrderStatus(id, status);
        }

        [HttpGet("getorderstatus")]
        public async Task<OrderServiceModel> GetStatus(int id)
        {
            return await _repository.GetStatus(id);
        }


        [HttpGet("orderbyid")]
        public async Task<OrderDto> GetOrderById(int id)
        {
            return await _repository.GetOrderById(id);
        }

        [HttpGet("orderbypharmacyid")]
        public async Task<IEnumerable<OrderDto>> GetOrderByPharmacyId(int id)
        {
            return await _repository.GetOrderByPharmacyId(id);
        }

        [HttpPut("deleteorder")]
        public async Task DeleteOrder(int id)
        {
            await _repository.DeleteOrder(id);
        }

    }
}
