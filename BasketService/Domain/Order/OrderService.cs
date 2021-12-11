using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Order
{
    public class OrderService
    {
        private readonly IOrderProvider _orderProvider;

        public OrderService(IOrderProvider orderProvider)
        {
            _orderProvider = orderProvider;
        }

        public async Task<ICollection<Order>> GetAllOrders()
        {
            return await _orderProvider.GetAllOrders();
        }

        public async Task<ICollection<Order>> GetAllUserOrders(UserId userId)
        {
            return await _orderProvider.GetAllUserOrders(userId);
        }

        public async Task<Order> GetOrder(OrderId orderId)
        {
            return await _orderProvider.GetOrder(orderId);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
