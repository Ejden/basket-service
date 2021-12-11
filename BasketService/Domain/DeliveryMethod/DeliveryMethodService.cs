using System.Collections.Generic;
using System.Threading.Tasks;
using BasketService.Infrastructure.Api.DeliveryMethod.Request;

namespace BasketService.Domain.DeliveryMethod
{
    public class DeliveryMethodService
    {
        private readonly IDeliveryMethodProvider _deliveryMethodProvider;
        
        public DeliveryMethodService(IDeliveryMethodProvider deliveryMethodProvider)
        {
            _deliveryMethodProvider = deliveryMethodProvider;
        }

        public async Task<ICollection<DeliveryMethod>> GetAllDeliveryMethods()
        {
            return await _deliveryMethodProvider.GetAllDeliveryMethods();
        }

        public async Task<DeliveryMethod> GetDeliveryMethod(DeliveryMethodId id)
        {
            return await _deliveryMethodProvider.GetDeliveryMethod(id);
        }

        public async Task<DeliveryMethod> CreateDeliveryMethod(CreateDeliveryMethodRequest request)
        {
            DeliveryMethodValidator.ValidateCreateRequest(request);
            
            var newDeliveryMethod = DeliveryMethodFactory.CreateDeliveryFromRequest(request);
            return await _deliveryMethodProvider.CreateDeliveryMethod(newDeliveryMethod);
        }

        public async Task<DeliveryMethod> UpdateDeliveryMethod(
            DeliveryMethodId deliveryMethodId, 
            ModifyDeliveryMethodRequest request)
        {
            DeliveryMethodValidator.ValidateModifyRequest(request);
            
            var deliveryMethodToUpdate = await _deliveryMethodProvider.GetDeliveryMethod(deliveryMethodId);
            var updatedDeliveryMethod = deliveryMethodToUpdate
                .UpdateName(request.Name)
                .UpdateCost(request.Cost.ToDomain());

            return await _deliveryMethodProvider.UpdateDeliveryMethod(updatedDeliveryMethod);
        }

        public async Task DeleteDeliveryMethod(DeliveryMethodId id)
        {
            await _deliveryMethodProvider.DeleteDeliveryMethod(id);
        }
    }
}
