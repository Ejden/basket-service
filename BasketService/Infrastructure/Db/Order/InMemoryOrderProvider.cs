using System.Collections.Generic;
using System.Threading.Tasks;
using BasketService.Domain.Order;
using BasketService.Domain.Shared;
using OrderId = BasketService.Domain.Order.OrderId;

namespace BasketService.Infrastructure.Db.Order
{
    public class InMemoryOrderProvider : IOrderProvider
    {
        public Task<ICollection<Domain.Order.Order>> GetAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Domain.Order.Order>> GetAllUserOrders(UserId userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Domain.Order.Order> GetOrder(OrderId orderId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Domain.Order.Order> CreateOrder(Domain.Order.Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
