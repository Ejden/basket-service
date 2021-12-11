using BasketService.Infrastructure.Api.Shared;

namespace BasketService.Infrastructure.Api.DeliveryMethod.Dto
{
    public abstract class DeliveryMethodDtoMapper
    {
        public static DeliveryMethodDto ToDto(Domain.DeliveryMethod.DeliveryMethod deliveryMethod)
        {
            return new DeliveryMethodDto(
                deliveryMethod._id.Raw, 
                deliveryMethod._name, 
                MoneyDto.FromDomain(deliveryMethod._cost)
            );
        }
    }
}
