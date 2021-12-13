using System.Collections.Generic;
using System.Threading.Tasks;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Basket.Request;

namespace BasketService.Domain.Order
{
    public class OrderService
    {
        private readonly IOrderProvider _orderProvider;

        private readonly OrderFactory _orderFactory;

        public OrderService(IOrderProvider orderProvider, OrderFactory orderFactory)
        {
            _orderProvider = orderProvider;
            _orderFactory = orderFactory;
        }

        public async Task<ICollection<DetailedOrder.DetailedOrder>> GetAllOrders()
        {
            var orders = await _orderProvider.GetAllOrders();
            return await _orderFactory.ToDetailedOrders(orders);
        }

        public async Task<ICollection<DetailedOrder.DetailedOrder>> GetAllUserOrders(UserId userId)
        {
            var orders = await _orderProvider.GetAllUserOrders(userId);
            return await _orderFactory.ToDetailedOrders(orders);
        }

        public async Task<DetailedOrder.DetailedOrder> GetOrder(OrderId orderId)
        {
            var order = await _orderProvider.GetOrder(orderId);
            return await _orderFactory.ToDetailedOrder(order);
        }

        public async Task<DetailedOrder.DetailedOrder> CreateOrder(
            UserId userId, 
            CheckoutBasketRequest request, 
            Basket.Basket basket)
        {
            var order = await _orderFactory.CreateOrder(userId, request, basket);
            var createdOrder = await _orderProvider.CreateOrder(order);
            return await _orderFactory.ToDetailedOrder(createdOrder);
        }
    }
}
