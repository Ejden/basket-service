namespace BasketService.Infrastructure.Api.Basket.Dto
{
    public record DetailedItemDto(
        string ProductId,
        string Name,
        int Quantity
    );
}