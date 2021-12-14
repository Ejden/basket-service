using System.Threading.Tasks;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Basket.Dto;
using BasketService.Infrastructure.Api.Basket.Request;
using BasketService.Infrastructure.Api.Order.Dto;
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

        [HttpGet("users/{userId}/basket")]
        public async Task<IActionResult> GetUserBasket(string userId)
        {
            return Ok(BasketDtoMapper.ToDto(await _basketService.GetUserBasket(UserId.Of(userId))));
        }

        [HttpDelete("users/{userId}/basket")]
        public async Task<IActionResult> ClearUserBasket(string userId)
        {
            return Ok(BasketDtoMapper.ToDto(await _basketService.ClearUserBasket(UserId.Of(userId))));
        }

        [HttpPost("users/{userId}/basket/checkout")]
        public async Task<IActionResult> Checkout(string userId, [FromBody] CheckoutBasketRequest request)
        {
            return Ok(OrderDtoMapper.ToDto(await _basketService.Checkout(UserId.Of(userId), request)));
        }

        [HttpPost("users/{userId}/basket/items")]
        public async Task<IActionResult> AddItemToBasket(string userId, [FromBody] AddItemToBasketRequest request)
        {
            return Ok(BasketDtoMapper.ToDto(await _basketService.AddItemToBasket(UserId.Of(userId), request)));
        }

        [HttpPost("users/{userId}/basket/items/{productId}")]
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

        [HttpDelete("users/{userId}/basket/items/{productId}")]
        public async Task<IActionResult> RemoveItemFromBasket(string userId, string productId)
        {
            return Ok(BasketDtoMapper.ToDto(
                    await _basketService.RemoveItemFromBasket(UserId.Of(userId), ProductId.Of(productId))
                )
            );
        }
    }
}
