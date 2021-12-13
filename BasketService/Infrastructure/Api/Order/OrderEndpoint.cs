using System.Threading.Tasks;
using BasketService.Domain.Order;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Order.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Infrastructure.Api.Order
{
    [ApiController]
    [Route("/orders")]
    public class OrderEndpoint : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderEndpoint(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(OrderDtoMapper.ToDto(await _orderService.GetAllOrders()));
        }

        [HttpGet("/users/{userId}/orders")]
        public async Task<IActionResult> GetAllUserOrders(string userId)
        {
            return Ok(OrderDtoMapper.ToDto(await _orderService.GetAllUserOrders(UserId.Of(userId))));
        }

        [HttpGet("/orders/{orderId}")]
        public async Task<IActionResult> GetOrder(string orderId)
        {
            return Ok(OrderDtoMapper.ToDto(await _orderService.GetOrder(OrderId.Of(orderId))));
        }
    }
}
