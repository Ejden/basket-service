namespace BasketService.Domain.Shared
{
    public class User
    {
        public UserId Id { get; }
        
        public bool IsFreeDeliveryActive { get; } 

        public User(UserId id, bool isFreeDeliveryActive)
        {
            Id = id;
            IsFreeDeliveryActive = isFreeDeliveryActive;
        }
    }
}
