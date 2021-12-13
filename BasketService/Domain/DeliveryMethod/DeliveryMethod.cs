using BasketService.Domain.Shared;

namespace BasketService.Domain.DeliveryMethod
{
    public class DeliveryMethod
    {
        public readonly DeliveryMethodId Id;

        public readonly string Name;

        public readonly Money Cost;

        public readonly bool PickupMethod;

        public DeliveryMethod(DeliveryMethodId id, string name, Money cost, bool pickupMethod)
        {
            Id = id;
            Name = name;
            Cost = cost;
            PickupMethod = pickupMethod;
        }

        public DeliveryMethod UpdateName(string name)
        {
            return new DeliveryMethod(Id, name, Cost, PickupMethod);
        }

        public DeliveryMethod UpdateCost(Money cost)
        {
            return new DeliveryMethod(Id, Name, cost, PickupMethod);
        }
    }
}
