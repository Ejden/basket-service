using BasketService.Infrastructure.Db.Shared;

namespace BasketService.Infrastructure.Api.Basket.Dto
{
    public record ItemDto(string ProductId, MoneyDocument SingleItemPrice, int Quantity, MoneyDocument TotalPrice);
}
