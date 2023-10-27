using LMS.OrderService.API.Database;
using LMS.OrderService.API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoFramework.Linq;

namespace LMS.OrderService.API.Repository
{
    public class OrderServiceRepository : IOrderServiceRepository
    {
        private readonly OrderServiceApiContext _context;
        public OrderServiceRepository(OrderServiceApiContext context)
        {
            _context = context;
        }

        public async Task<OrderDto> CreateOrder(OrderDto dto)
        {
            _context.Orders.Add(dto.CustomerOrder);
            _context.OrderItems.AddRange(dto.Items);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteOrder(int id)
        {
            var orderToDelete = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (orderToDelete != null)
            {
                _context.Orders.Remove(orderToDelete);
                var orderItemToDelete = await _context.OrderItems.Where(x => x.OrderId == orderToDelete.Id).ToListAsync();
                _context.OrderItems.RemoveRange(orderItemToDelete);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderServiceModel>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemByOrderId(int Id)
        {
            return await _context.OrderItems.Where(x => x.OrderId == Id).ToListAsync();
        }

        public async Task<OrderDto> GetOrderById(int id)
        {
            var _order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (_order != null)
            {
                var _orderItem = await _context.OrderItems.Where(x => x.OrderId == _order.Id).ToListAsync();
                return new OrderDto { CustomerOrder = _order, Items = _orderItem };
            }

            return null;
        }

        public async Task<IEnumerable<OrderDto>> GetOrderByPharmacyId(int id)
        {
            List<OrderDto> dto = new List<OrderDto>();

            var _order = await _context.Orders.Where(x => x.PharmacyId == id).ToListAsync();


            foreach (var item in _order)
            {
                var dt = new OrderDto();
                var _orderItem = await _context.OrderItems.Where(x => x.OrderId == item.Id).ToListAsync();

                dt.CustomerOrder = item;
                dt.Items = _orderItem;

                dto.Add(dt);
            }

            return dto;
        }

        public async Task<OrderServiceModel> GetStatus(int id)
        {
            var res = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }

        public async Task<bool> UpdateOrderStatus(int id, string status)
        {
            var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            orderToUpdate.OrderStatus = status;

            _context.Orders.Update(orderToUpdate);

            await _context.SaveChangesAsync();

            return true;
        }
    
    }
}
