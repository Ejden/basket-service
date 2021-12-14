using BasketService.Domain.Shared;

namespace BasketService.Domain.Order.DetailedOrder
{
    public abstract class DetailedOrderDelivery
    {
        public readonly DetailedDeliveryMethod DeliveryMethod;
        
        public readonly Money Cost;

        public DetailedOrderDelivery(DetailedDeliveryMethod deliveryMethod, Money cost)
        {
            DeliveryMethod = deliveryMethod;
            Cost = cost;
        }
    }

    public class DetailedPickupPointOrderDelivery : DetailedOrderDelivery
    {
        public readonly string PickupPoint;
        
        public DetailedPickupPointOrderDelivery(
            DetailedDeliveryMethod deliveryMethod, 
            string pickupPoint,
            Money cost) : base(deliveryMethod, cost)
        {
            PickupPoint = pickupPoint;
        }
    }

    public class DetailedAddressOrderDelivery : DetailedOrderDelivery
    {
        public readonly string Address;
        
        public DetailedAddressOrderDelivery(
            DetailedDeliveryMethod deliveryMethod,
            string address,
            Money cost) : base(deliveryMethod, cost)
        {
            Address = address;
        }
    }
}
