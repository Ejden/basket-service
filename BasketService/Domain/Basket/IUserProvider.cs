using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public interface IUserProvider
    {
        public User GetUser(UserId userId);
    }
}
