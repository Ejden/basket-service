using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketService.Domain.DeliveryMethod
{
    public interface IDeliveryMethodProvider
    {
        public Task<ICollection<DeliveryMethod>> GetAllDeliveryMethods();

        public Task<DeliveryMethod> GetDeliveryMethod(DeliveryMethodId id);

        public Task<DeliveryMethod> CreateDeliveryMethod(DeliveryMethod deliveryMethod);

        public Task<DeliveryMethod> UpdateDeliveryMethod(DeliveryMethod deliveryMethod);

        public Task DeleteDeliveryMethod(DeliveryMethodId id);
    }
}
