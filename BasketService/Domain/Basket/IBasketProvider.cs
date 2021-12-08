using System.Collections.Generic;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public interface IBasketProvider
    {
        public ICollection<Basket> GetAllBaskets();

        public Basket GetUserBasket(UserId userId);

        public Basket Create(Basket basket);

        public Basket Update(Basket basket);
    }
}
