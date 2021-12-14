using BasketService.Domain.DeliveryMethod;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Order
{
    public abstract class OrderDelivery
    {
        public readonly DeliveryMethodId DeliveryMethodId;
        
        public readonly Money Cost;

        public OrderDelivery(DeliveryMethodId deliveryMethodId, Money cost)
        {
            DeliveryMethodId = deliveryMethodId;
            Cost = cost;
        }
    }

    public class PickupPointOrderDelivery : OrderDelivery
    {
        public readonly string PickupPoint;
        
        public PickupPointOrderDelivery(
            DeliveryMethodId deliveryMethodId,
            string pickupPoint,
            Money cost) : base(deliveryMethodId, cost)
        {
            PickupPoint = pickupPoint;
        }
    }

    public class AddressOrderDelivery : OrderDelivery
    {
        public readonly string Address;
            
        public AddressOrderDelivery(
            DeliveryMethodId deliveryMethodId,
            string address,
            Money cost) : base(deliveryMethodId, cost)
        {
            Address = address;
        }
    }
}
