using BasketService.Infrastructure.Db.Shared;
using MongoDB.Bson.Serialization.Attributes;

namespace BasketService.Infrastructure.Db.Order.Model
{
    public class OrderDeliveryDocument
    {
        [BsonElement("deliveryMethodId")]
        public string DeliveryMethodId { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("cost")] 
        public MoneyDocument Cost { get; set; }

        public OrderDeliveryDocument() { }

        public OrderDeliveryDocument(string deliveryMethodId, string address, MoneyDocument cost)
        {
            DeliveryMethodId = deliveryMethodId;
            Address = address;
            Cost = cost;
        }
    }
}
