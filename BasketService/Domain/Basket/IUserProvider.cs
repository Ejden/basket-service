using System.Threading.Tasks;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public interface IUserProvider
    {
        public Task<User> GetUser(UserId userId);
    }
}
