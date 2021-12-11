using System.Collections.Immutable;

namespace BasketService.Domain.Order
{
    public class Order
    {
        public readonly OrderId Id;

        public readonly Buyer Buyer;

        public readonly ImmutableList<OrderItem> Items;

        public readonly OrderDelivery Delivery;

        public Order(OrderId id, Buyer buyer, ImmutableList<OrderItem> items, OrderDelivery delivery)
        {
            Id = id;
            Buyer = buyer;
            Items = items;
            Delivery = delivery;
        }
    }
}
