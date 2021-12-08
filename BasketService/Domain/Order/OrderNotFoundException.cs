using BasketService.Domain.Shared;

namespace BasketService.Domain.Order
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(OrderId orderId) : base($"Order with id {orderId.Raw} not found") { }
    }
}
