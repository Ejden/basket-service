using System.Collections.Immutable;

namespace BasketService.Infrastructure.Api.Basket.Dto
{
    public record BasketDto(
        string Id,
        UserDto Buyer,
        IImmutableList<ItemDto> Items,
        MoneyDto TotalItemsCost
    );
}
