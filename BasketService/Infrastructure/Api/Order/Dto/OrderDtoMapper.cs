using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BasketService.Domain.Order;
using BasketService.Domain.Order.DetailedOrder;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Shared;

namespace BasketService.Infrastructure.Api.Order.Dto
{
    public abstract class OrderDtoMapper
    {
        public static DetailedOrderDto ToDto(DetailedOrder order)
        {
            return new DetailedOrderDto(
                order.Id.Raw,
                ToDto(order.Buyer),
                order.OrderTimestamp,
                order.Items.Select(ToDto).ToImmutableList(),
                ToDto(order.Delivery),
                MoneyDto.FromDomain(order.TotalCost)
            );
        }

        private static BuyerDto ToDto(Buyer buyer)
        {
            return new BuyerDto(buyer.Id.Raw);
        }

        private static DetailedItemDto ToDto(DetailedOrderItem item)
        {
            return new DetailedItemDto(
                item.ProductId.Raw,
                item.Name,
                item.Quantity,
                MoneyDto.FromDomain(item.SingleItemCost),
                MoneyDto.FromDomain(item.TotalCost)
            );
        }

        private static DetailedDeliveryDto ToDto(DetailedOrderDelivery delivery)
        {
            return delivery switch
            {
                DetailedAddressOrderDelivery addressDelivery => new DetailedDeliveryDto(
                    DeliveryMethod: new DetailedDeliveryMethodDto(addressDelivery.DeliveryMethod.Id.Raw,
                        addressDelivery.DeliveryMethod.Name),
                    Address: addressDelivery.Address,
                    PickupPoint: null
                ),
                DetailedPickupPointOrderDelivery pickupDelivery => new DetailedDeliveryDto(
                    DeliveryMethod: new DetailedDeliveryMethodDto(pickupDelivery.DeliveryMethod.Id.Raw,
                        pickupDelivery.DeliveryMethod.Name),
                    PickupPoint: pickupDelivery.PickupPoint,
                    Address: null
                ),
                _ => throw new ServiceException("Service error")
            };
        }
        
        public static OrdersDto ToDto(ICollection<DetailedOrder> orders)
        {
            return new OrdersDto(orders.Select(ToDto).ToImmutableList());
        }
    }
}
