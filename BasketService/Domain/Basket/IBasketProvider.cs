using System.Collections.Generic;
using System.Threading.Tasks;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public interface IBasketProvider
    {
        public Task<ICollection<Basket>> GetAllBaskets();

        public Task<Basket> GetUserBasket(UserId userId);

        public void DeleteUserBasket(UserId userId);

        public Task<Basket> Create(Basket basket);

        public Task<Basket> Update(Basket basket);
    }
}
