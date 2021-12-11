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
                deliveryMethod.Cost.ToDomain()
            );
        }

        public static DeliveryMethodDocument ToDocument(Domain.DeliveryMethod.DeliveryMethod deliveryMethod)
        {
            return new DeliveryMethodDocument(
                deliveryMethod._id.Raw ?? Guid.NewGuid().ToString(),
                deliveryMethod._name,
                MoneyDocument.FromDomain(deliveryMethod._cost)
            );
        }
    }
}
