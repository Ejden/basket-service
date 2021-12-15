using System.Collections.Immutable;

namespace BasketService.Infrastructure.Api.Basket.Dto
{
    public record DetailedBasketDto(
        string Id,
        UserDto Buyer,
        IImmutableList<DetailedItemDto> Items,
        MoneyDto TotalItemsCost
    );
}