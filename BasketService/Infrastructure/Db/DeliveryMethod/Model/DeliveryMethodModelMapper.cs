using System;
using BasketService.Domain.DeliveryMethod;
using BasketService.Infrastructure.Db.Shared;

namespace BasketService.Infrastructure.Db.DeliveryMethod.Model
{
    public abstract class DeliveryMethodModelMapper
    {
        public static Domain.DeliveryMethod.DeliveryMethod ToDomain(DeliveryMethodDocument deliveryMethod)
        {
            return new Domain.DeliveryMethod.DeliveryMethod(
                DeliveryMethodId.Of(deliveryMethod.Id),
                deliveryMethod.Name,
                deliveryMethod.Cost.ToDomain(),
                deliveryMethod.PickupMethod
            );
        }

        public static DeliveryMethodDocument ToDocument(Domain.DeliveryMethod.DeliveryMethod deliveryMethod)
        {
            return new DeliveryMethodDocument(
                deliveryMethod.Id.Raw ?? Guid.NewGuid().ToString(),
                deliveryMethod.Name,
                MoneyDocument.FromDomain(deliveryMethod.Cost),
                deliveryMethod.PickupMethod
            );
        }
    }
}
