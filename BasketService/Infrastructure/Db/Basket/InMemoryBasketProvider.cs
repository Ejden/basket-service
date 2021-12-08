using System.Collections.Generic;
using BasketService.Domain.Basket;
using BasketService.Domain.Shared;

namespace BasketService.Infrastructure.Db.Basket
{
    public class InMemoryBasketProvider : IBasketProvider
    {
        public ICollection<Domain.Basket.Basket> GetAllBaskets()
        {
            throw new System.NotImplementedException();
        }

        public Domain.Basket.Basket GetUserBasket(UserId userId)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Basket.Basket Create(Domain.Basket.Basket basket)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Basket.Basket Update(Domain.Basket.Basket basket)
        {
            throw new System.NotImplementedException();
        }
    }
}
