using System.Collections.Generic;
using BasketService.Domain.Order;
using BasketService.Domain.Shared;

namespace BasketService.Infrastructure.Db.Order
{
    public class InMemoryOrderProvider : IOrderProvider
    {
        public ICollection<Domain.Order.Order> GetAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Domain.Order.Order> GetAllUserOrders(UserId userId)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Order.Order GetOrder(OrderId orderId)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Order.Order Insert(Domain.Order.Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
