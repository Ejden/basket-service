using BasketService.Domain.Shared;

namespace BasketService.Domain.DeliveryMethod
{
    public class DeliveryMethodNotFoundException : NotFoundException
    {
        public DeliveryMethodNotFoundException(DeliveryMethodId id) : base($"Delivery method with id {id} not found") { }
    }
}
