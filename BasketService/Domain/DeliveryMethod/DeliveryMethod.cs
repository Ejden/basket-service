using BasketService.Domain.Shared;

namespace BasketService.Domain.DeliveryMethod
{
    public class DeliveryMethod
    {
        public readonly DeliveryMethodId _id;

        public readonly string _name;

        public readonly Money _cost;

        public DeliveryMethod(DeliveryMethodId id, string name, Money cost)
        {
            _id = id;
            _name = name;
            _cost = cost;
        }

        public DeliveryMethod UpdateName(string name)
        {
            return new DeliveryMethod(_id, name, _cost);
        }

        public DeliveryMethod UpdateCost(Money cost)
        {
            return new DeliveryMethod(_id, _name, cost);
        }
    }
}
