using BasketService.Infrastructure.Api.Shared;

namespace BasketService.Infrastructure.Api.DeliveryMethod.Request
{
    public record CreateDeliveryMethodRequest(string Name, MoneyDto Cost, bool PickupMethod);
}
