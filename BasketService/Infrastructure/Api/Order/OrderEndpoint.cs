using System;
using System.Threading.Tasks;
using BasketService.Domain.Order;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Order.Dto;
using BasketService.Infrastructure.Api.Order.Request;
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
        public async Task<IActionResult> GetAllUserOrders(UserId userId)
        {
            return Ok(OrderDtoMapper.ToDto(await _orderService.GetAllUserOrders(userId)));
        }

        [HttpGet("/orders/{orderId}")]
        public async Task<IActionResult> GetOrder(OrderId orderId)
        {
            return Ok(OrderDtoMapper.ToDto(await _orderService.GetOrder(orderId)));
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(PlaceOrderRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
