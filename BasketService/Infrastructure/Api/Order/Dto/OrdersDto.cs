using System.Collections.Immutable;

namespace BasketService.Infrastructure.Api.Order.Dto
{
    public record OrdersDto(ImmutableList<DetailedOrderDto> Orders);
}
