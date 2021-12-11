using BasketService.Domain.DeliveryMethod;

namespace BasketService.Domain.Order
{
    public class OrderDelivery
    {
        public readonly DeliveryMethodId DeliveryMethodId;
        
        public readonly string Address;

        public OrderDelivery(DeliveryMethodId deliveryMethodId, string address)
        {
            DeliveryMethodId = deliveryMethodId;
            Address = address;
        }
    }
}
