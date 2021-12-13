using BasketService.Domain.DeliveryMethod;

namespace BasketService.Domain.Order.DetailedOrder
{
    public class DetailedDeliveryMethod
    {
        public readonly DeliveryMethodId Id;

        public readonly string Name;

        public DetailedDeliveryMethod(DeliveryMethodId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
