using BasketService.Domain.Shared;

namespace BasketService.Domain.DeliveryMethod
{
    public class DeliveryMethod
    {
        public readonly DeliveryMethodId Id;

        public readonly string Name;

        public readonly Money Cost;

        public DeliveryMethod(DeliveryMethodId id, string name, Money cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }

        public DeliveryMethod UpdateName(string name)
        {
            return new DeliveryMethod(Id, name, Cost);
        }

        public DeliveryMethod UpdateCost(Money cost)
        {
            return new DeliveryMethod(Id, Name, cost);
        }
    }
}
