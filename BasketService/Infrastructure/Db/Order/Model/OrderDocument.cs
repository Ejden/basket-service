using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using BasketService.Infrastructure.Db.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasketService.Infrastructure.Db.Order.Model
{
    public class OrderDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("buyerId")]
        public string BuyerId { get; set; }

        [BsonElement("orderTimestamp")] 
        public DateTime OrderTimestamp { get; set; }

        [BsonElement("items")]
        public List<OrderItemDocument> Items { get; set; }

        [BsonElement("delivery")]
        public OrderDeliveryDocument Delivery { get; set; }

        [BsonElement("totalCost")] 
        public MoneyDocument TotalCost { get; set; }

        public OrderDocument() { }

        public OrderDocument(
            string id, 
            string buyerId, 
            DateTime orderTimestamp, 
            List<OrderItemDocument> items, 
            OrderDeliveryDocument delivery,
            MoneyDocument totalCost)
        {
            Id = id;
            BuyerId = buyerId;
            OrderTimestamp = orderTimestamp;
            Items = items;
            Delivery = delivery;
            TotalCost = totalCost;
        }
    }
}
