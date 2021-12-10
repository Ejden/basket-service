using System;
using System.Collections.Immutable;
using System.Linq;
using BasketService.Domain.Basket;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Db.Shared;

namespace BasketService.Infrastructure.Db.Basket.Model
{
    public abstract class BasketModelMapper
    {
        public static Domain.Basket.Basket ToDomain(BasketDocument basket)
        {
            return new Domain.Basket.Basket(
                BasketId.Of(basket.Id),
                UserId.Of(basket.Buyer.Id),
                basket.Items.Select(ToDomain).ToImmutableList()
            );
        }

        private static Item ToDomain(ItemDocument item)
        {
            return new Item(ProductId.Of(item.ProductId), ToDomain(item.Price), item.Quantity);
        }

        private static Money ToDomain(MoneyDocument money)
        {
            return new Money(money.Amount, Enum.Parse<Currency>(money.Currency));
        }

        public static BasketDocument ToDocument(Domain.Basket.Basket basket)
        {
            return new BasketDocument(
                basket.Id.Raw,
                ToDocument(basket.Buyer),
                basket.Items.Select(ToDocument).ToList()
            );
        }

        private static UserDocument ToDocument(Domain.Basket.Basket.User user)
        {
            return new UserDocument(user.UserId.Raw);
        }

        private static ItemDocument ToDocument(Item item)
        {
            return new ItemDocument(item.ProductId.Raw, ToDocument(item.Price), item.Quantity);
        }

        private static MoneyDocument ToDocument(Money money)
        {
            return new MoneyDocument(money.Amount, money.Currency.ToString());
        }
    }
}
