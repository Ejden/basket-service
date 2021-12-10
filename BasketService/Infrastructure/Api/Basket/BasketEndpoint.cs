using System.Threading.Tasks;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Basket.Dto;
using BasketService.Infrastructure.Api.Basket.Request;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Infrastructure.Api.Basket
{
    [ApiController]
    public class BasketEndpoint : ControllerBase
    {
        private readonly Domain.Basket.BasketService _basketService;

        public BasketEndpoint(Domain.Basket.BasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        [Route("users/{userId}/basket")]
        public async Task<IActionResult> GetUserBasket(string userId)
        {
            return Ok(BasketDtoMapper.ToDto(await _basketService.GetUserBasket(UserId.Of(userId))));
        }

        [HttpDelete]
        [Route("users/{userId}/basket")]
        public async Task<IActionResult> ClearUserBasket(string userId)
        {
            return Ok(BasketDtoMapper.ToDto(await _basketService.ClearUserBasket(UserId.Of(userId))));
        }

        [HttpPost]
        [Route("users/{userId}/basket/items")]
        public async Task<IActionResult> AddItemToBasket(string userId, [FromBody] AddItemToBasketRequest request)
        {
            return Ok(BasketDtoMapper.ToDto(await _basketService.AddItemToBasket(UserId.Of(userId), request)));
        }

        [HttpPost]
        [Route("users/{userId}/basket/items/{productId}")]
        public async Task<IActionResult> ModifyItemInBasket(
            string userId, 
            string productId,
            [FromBody] ModifyItemInBasketRequest request)
        {
            return Ok(BasketDtoMapper.ToDto(
                    await _basketService.ModifyItemInBasket(UserId.Of(userId), ProductId.Of(productId), request)
                )
            );
        }

        [HttpDelete]
        [Route("users/{userId}/basket/items/{productId}")]
        public async Task<IActionResult> RemoveItemFromBasket(string userId, string productId)
        {
            return Ok(BasketDtoMapper.ToDto(
                    await _basketService.RemoveItemFromBasket(UserId.Of(userId), ProductId.Of(productId))
                )
            );
        }
    }
}
