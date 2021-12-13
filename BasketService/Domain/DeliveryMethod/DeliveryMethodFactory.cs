using System;
using BasketService.Infrastructure.Api.DeliveryMethod.Request;

namespace BasketService.Domain.DeliveryMethod
{
    public abstract class DeliveryMethodFactory
    {
        public static DeliveryMethod CreateDeliveryFromRequest(CreateDeliveryMethodRequest request)
        {
            return new DeliveryMethod(
                DeliveryMethodId.Of(Guid.NewGuid().ToString()),
                request.Name,
                request.Cost.ToDomain(),
                request.PickupMethod
            );
        }
    }
}
