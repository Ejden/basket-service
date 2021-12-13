using System;
using System.Collections.Immutable;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Order.DetailedOrder
{
    public class DetailedOrder
    {
        public readonly OrderId Id;

        public readonly Buyer Buyer;

        public readonly DateTime OrderTimestamp;

        public readonly ImmutableList<DetailedOrderItem> Items;

        public readonly DetailedOrderDelivery Delivery;

        public readonly Money TotalCost;

        public DetailedOrder(
            OrderId id, 
            Buyer buyer, 
            DateTime orderTimestamp, 
            ImmutableList<DetailedOrderItem> items, 
            DetailedOrderDelivery delivery, 
            Money totalCost)
        {
            Id = id;
            Buyer = buyer;
            OrderTimestamp = orderTimestamp;
            Items = items;
            Delivery = delivery;
            TotalCost = totalCost;
        }
    }
}
