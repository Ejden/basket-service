using BasketService.Domain.DeliveryMethod;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Order
{
    public class OrderDelivery
    {
        public readonly DeliveryMethodId DeliveryMethodId;
        
        public readonly string Address;

        public readonly Money Cost;

        public OrderDelivery(DeliveryMethodId deliveryMethodId, string address, Money cost)
        {
            DeliveryMethodId = deliveryMethodId;
            Address = address;
            Cost = cost;
        }
    }
}
