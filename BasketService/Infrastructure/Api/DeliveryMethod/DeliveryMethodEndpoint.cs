using System.Linq;
using System.Threading.Tasks;
using BasketService.Domain.DeliveryMethod;
using BasketService.Infrastructure.Api.DeliveryMethod.Dto;
using BasketService.Infrastructure.Api.DeliveryMethod.Request;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Infrastructure.Api.DeliveryMethod
{
    [ApiController]
    [Route("/delivery-methods")]
    public class DeliveryMethodEndpoint : ControllerBase
    {
        private readonly DeliveryMethodService _deliveryMethodService;

        public DeliveryMethodEndpoint(DeliveryMethodService deliveryMethodService)
        {
            _deliveryMethodService = deliveryMethodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeliveryMethods()
        {
            var deliveryMethods = await _deliveryMethodService.GetAllDeliveryMethods();
            return Ok(deliveryMethods.Select(DeliveryMethodDtoMapper.ToDto));
        }

        [HttpGet("{deliveryMethodId}")]
        public async Task<IActionResult> GetDeliveryMethod(string deliveryMethodId)
        {
            return Ok(DeliveryMethodDtoMapper.ToDto(
                await _deliveryMethodService.GetDeliveryMethod(DeliveryMethodId.Of(deliveryMethodId))));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeliveryMethod([FromBody] CreateDeliveryMethodRequest request)
        {
            return Ok(DeliveryMethodDtoMapper.ToDto(await _deliveryMethodService.CreateDeliveryMethod(request)));
        }

        [HttpPost("{deliveryMethodId}")]
        public async Task<IActionResult> UpdateDeliveryMethod(
            string deliveryMethodId, 
            [FromBody] ModifyDeliveryMethodRequest request)
        {
            return Ok(DeliveryMethodDtoMapper.ToDto(
                await _deliveryMethodService.UpdateDeliveryMethod(DeliveryMethodId.Of(deliveryMethodId), request)));
        }

        [HttpDelete("{deliveryMethodId}")]
        public async Task<IActionResult> DeleteDeliveryMethod(string deliveryMethodId)
        {
            await _deliveryMethodService.DeleteDeliveryMethod(DeliveryMethodId.Of(deliveryMethodId));
            return Ok();
        }
    }
}
