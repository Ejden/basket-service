using System.Collections.Generic;
using System.Threading.Tasks;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Order
{
    public interface IOrderProvider
    {
        public Task<ICollection<Order>> GetAllOrders();

        public Task<ICollection<Order>> GetAllUserOrders(UserId userId);

        public Task<Order> GetOrder(OrderId orderId);

        public Task<Order> CreateOrder(Order order);
    }
}
