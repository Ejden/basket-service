using System.Collections.Generic;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Order
{
    public interface IOrderProvider
    {
        public ICollection<Order> GetAllOrders();

        public ICollection<Order> GetAllUserOrders(UserId userId);

        public Order GetOrder(OrderId orderId);

        public Order Insert(Order order);
    }
}
