using System.Collections.Generic;
using System.Threading.Tasks;
using BasketService.Domain.Basket;
using BasketService.Domain.Shared;

namespace BasketService.Infrastructure.Db.Basket
{
    public class InMemoryBasketProvider : IBasketProvider
    {
        public Task<ICollection<Domain.Basket.Basket>> GetAllBaskets()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUserBasket(UserId userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Domain.Basket.Basket> GetUserBasket(UserId userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Domain.Basket.Basket> CreateBasket(Domain.Basket.Basket basket)
        {
            throw new System.NotImplementedException();
        }

        public Task<Domain.Basket.Basket> UpdateBasket(Domain.Basket.Basket basket)
        {
            throw new System.NotImplementedException();
        }
    }
}
