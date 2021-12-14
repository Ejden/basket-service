using System;
using System.Collections.Immutable;
using BasketService.Infrastructure.Api.Shared;

namespace BasketService.Infrastructure.Api.Order.Dto
{
    public record DetailedOrderDto(
        string Id, 
        BuyerDto Buyer, 
        DateTime OrderTimestamp, 
        ImmutableList<DetailedItemDto> Items, 
        DetailedDeliveryDto Delivery,
        MoneyDto TotalCost
    );

    public record BuyerDto(string Id);

    public record DetailedItemDto(
        string ProductId,
        string Name,
        int Quantity,
        MoneyDto SingleItemCost,
        MoneyDto TotalCost
    );

    public record DetailedDeliveryDto(
        DetailedDeliveryMethodDto DeliveryMethod,
        string PickupPoint,
        string Address

    );

    public record DetailedDeliveryMethodDto(
        string Id,
        string Name
    );
}
