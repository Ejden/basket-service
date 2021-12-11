using MongoDB.Bson.Serialization.Attributes;

namespace BasketService.Infrastructure.Db.Order.Model
{
    public class OrderDeliveryDocument
    {
        [BsonElement("deliveryMethodId")]
        public readonly string DeliveryMethodId;

        [BsonElement("address")]
        public readonly string Address;

        public OrderDeliveryDocument(string deliveryMethodId, string address)
        {
            DeliveryMethodId = deliveryMethodId;
            Address = address;
        }
    }
}
