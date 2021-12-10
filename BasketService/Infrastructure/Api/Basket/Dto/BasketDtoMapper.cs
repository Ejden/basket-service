using System.Collections.Immutable;
using System.Linq;
using BasketService.Domain.Basket;
using BasketService.Domain.Shared;

namespace BasketService.Infrastructure.Api.Basket.Dto
{
    public abstract class BasketDtoMapper
    {
        public static BasketDto ToDto(Domain.Basket.Basket basket)
        {
            return new BasketDto(
                basket.Id.Raw,
                new UserDto(basket.Buyer.UserId.Raw),
                basket.Items.Select(ToDto).ToImmutableList(),
                ToDto(basket.TotalItemsCost)
            );
        }

        private static ItemDto ToDto(Item item)
        {
            return new ItemDto(item.ProductId.Raw, item.Quantity);
        }

        private static MoneyDto ToDto(Money money)
        {
            return new MoneyDto(money.Amount, money.Currency.ToString());
        }
    }
}
