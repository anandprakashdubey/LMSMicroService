using LMS.OrderService.API.Models;

namespace LMS.OrderService.API.Repository
{
    public interface IOrderServiceRepository
    {
        public Task<OrderDto> CreateOrder(OrderDto dto);

        public Task<IEnumerable<OrderServiceModel>> GetAllOrders();

        public Task<IEnumerable<OrderItem>> GetAllOrderItemByOrderId(int Id);

        public Task<bool> UpdateOrderStatus(int id, string status);

        public Task<OrderServiceModel> GetStatus(int id);

        public Task<OrderDto> GetOrderById(int id);

        public Task<IEnumerable<OrderDto>> GetOrderByPharmacyId(int id);

        public Task DeleteOrder(int id);

    }
}
