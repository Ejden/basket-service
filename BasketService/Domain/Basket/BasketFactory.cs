using System;
using System.Collections.Immutable;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public abstract class BasketFactory
    {
        public static Basket CreateBasketWithoutItems(UserId userId)
        {
            return new Basket(
                BasketId.Of(Guid.NewGuid().ToString()),
                userId,
                ImmutableList<Item>.Empty
            );
        }
    }
}
