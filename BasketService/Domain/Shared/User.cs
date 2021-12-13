namespace BasketService.Domain.Shared
{
    public class User
    {
        public readonly UserId Id;

        public readonly bool IsFreeDeliveryActive;

        public User(UserId id, bool isFreeDeliveryActive)
        {
            Id = id;
            IsFreeDeliveryActive = isFreeDeliveryActive;
        }
    }
}
