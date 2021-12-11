using System.Collections.Generic;

namespace BasketService.Infrastructure.Api.Order.Dto
{
    public abstract class OrderDtoMapper
    {
        public static OrderDto ToDto(Domain.Order.Order order)
        {
            return new OrderDto();
        }

        public static OrdersDto ToDto(ICollection<Domain.Order.Order> orders)
        {
            return new OrdersDto();
        }
    }
}
