using BasketService.Infrastructure.Api.Shared;

namespace BasketService.Infrastructure.Api.DeliveryMethod.Request
{
    public record ModifyDeliveryMethodRequest(string Name, MoneyDto Cost);
}
