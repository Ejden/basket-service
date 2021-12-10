using BasketService.Domain.Basket;
using BasketService.Domain.Shared;

namespace BasketService.Infrastructure.Client
{
    public class FakeUserProvider : IUserProvider
    {
        private readonly User _fakeUser = new User(UserId.Of("fake-user"));
        
        public User GetUser(UserId userId)
        {
            return _fakeUser;
        }
    }
}
