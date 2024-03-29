﻿using System;
using System.Collections.Immutable;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Order
{
    public class Order
    {
        public readonly OrderId Id;

        public readonly Buyer Buyer;

        public readonly DateTime OrderTimestamp;

        public readonly ImmutableList<OrderItem> Items;

        public readonly OrderDelivery Delivery;

        public readonly Money TotalCost;
        
        public Order(
            OrderId id, 
            Buyer buyer, 
            DateTime orderTimestamp, 
            ImmutableList<OrderItem> items, 
            OrderDelivery delivery,
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
