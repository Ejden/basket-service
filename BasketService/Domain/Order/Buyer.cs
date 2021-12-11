using BasketService.Domain.Shared;

namespace BasketService.Domain.Order
{
    public class Buyer
    {
        public readonly UserId Id;

        public Buyer(UserId id)
        {
            Id = id;
        }
    }
}
