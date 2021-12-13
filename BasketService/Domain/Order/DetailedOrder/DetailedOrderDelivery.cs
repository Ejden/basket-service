using BasketService.Domain.Shared;

namespace BasketService.Domain.Order.DetailedOrder
{
    public class DetailedOrderDelivery
    {
        public readonly DetailedDeliveryMethod DeliveryMethod;

        public readonly string Address;

        public readonly Money Cost;

        public DetailedOrderDelivery(DetailedDeliveryMethod deliveryMethod, string address, Money cost)
        {
            DeliveryMethod = deliveryMethod;
            Address = address;
            Cost = cost;
        }
    }
}
