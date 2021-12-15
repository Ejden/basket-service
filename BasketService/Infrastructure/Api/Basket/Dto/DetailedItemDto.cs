using BasketService.Infrastructure.Db.Shared;

namespace BasketService.Infrastructure.Api.Basket.Dto
{
    public record DetailedItemDto(
        string ProductId,
        string Name,
        MoneyDocument SingleItemPrice, 
        int Quantity,
        MoneyDocument TotalPrice
    );
}