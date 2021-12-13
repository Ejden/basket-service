using System.Collections.Immutable;
using System.Linq;
using BasketService.Domain.DeliveryMethod;
using BasketService.Domain.Order;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Db.Shared;
using OrderId = BasketService.Domain.Order.OrderId;

namespace BasketService.Infrastructure.Db.Order.Model
{
    public abstract class OrderModelMapper
    {
        public static Domain.Order.Order ToDomain(OrderDocument order)
        {
            return new Domain.Order.Order(
                OrderId.Of(order.Id),
                new Buyer(UserId.Of(order.BuyerId)),
                order.OrderTimestamp,
                order.Items.Select(ToDomain).ToImmutableList(),
                ToDomain(order.Delivery),
                order.TotalCost.ToDomain()
            );
        }

        private static OrderItem ToDomain(OrderItemDocument orderItem)
        {
            return new OrderItem(
                ProductId.Of(orderItem.ProductId),
                orderItem.Quantity,
                orderItem.SingleItemCost.ToDomain(),
                orderItem.TotalCost.ToDomain()
            );
        }

        private static OrderDelivery ToDomain(OrderDeliveryDocument delivery)
        {
            return new OrderDelivery(
                DeliveryMethodId.Of(delivery.DeliveryMethodId),
                delivery.Address,
                delivery.Cost.ToDomain()
            );
        }

        public static OrderDocument ToDocument(Domain.Order.Order order)
        {
            return new OrderDocument(
                order.Id.Raw,
                order.Buyer.Id.Raw,
                order.OrderTimestamp,
                order.Items.Select(ToDocument).ToList(),
                ToDocument(order.Delivery),
                MoneyDocument.FromDomain(order.TotalCost)
            );
        }

        private static OrderItemDocument ToDocument(OrderItem orderItem)
        {
            return new OrderItemDocument(
                orderItem.ProductId.Raw,
                orderItem.Quantity,
                MoneyDocument.FromDomain(orderItem.SingleItemCost),
                MoneyDocument.FromDomain(orderItem.TotalCost)
            );
        }

        private static OrderDeliveryDocument ToDocument(OrderDelivery delivery)
        {
            return new OrderDeliveryDocument(
                delivery.DeliveryMethodId.Raw,
                delivery.Address,
                MoneyDocument.FromDomain(delivery.Cost)
            );
        }
    }
}
