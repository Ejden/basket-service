using System.Collections.Immutable;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasketService.Infrastructure.Db.Order.Model
{
    public class OrderDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("id")]
        public readonly string Id;

        [BsonElement("buyerId")]
        public readonly string BuyerId;

        [BsonElement("items")]
        public readonly ImmutableList<OrderItemDocument> Items;

        [BsonElement("delivery")]
        public readonly OrderDeliveryDocument Delivery;

        public OrderDocument(string id, string buyerId, ImmutableList<OrderItemDocument> items, OrderDeliveryDocument delivery)
        {
            Id = id;
            BuyerId = buyerId;
            Items = items;
            Delivery = delivery;
        }
    }
}
