using BasketService.Infrastructure.Api.Shared;

namespace BasketService.Infrastructure.Api.DeliveryMethod.Dto
{
    public record DeliveryMethodDto(string Id, string Name, MoneyDto Cost);
}
