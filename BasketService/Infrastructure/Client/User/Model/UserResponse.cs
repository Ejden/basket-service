using BasketService.Domain.Shared;

namespace BasketService.Infrastructure.Client.User.Model
{
    public class UserResponse
    {
        public string Id { get; set; }
        
        public bool IsFreeDeliveryActive { get; set; }

        public Domain.Shared.User ToDomain()
        {
            return new Domain.Shared.User(UserId.Of(Id), IsFreeDeliveryActive);
        }
    }
}
