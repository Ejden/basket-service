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
        
        [BsonElement("pickupPoint")]
        public string PickupPoint { get; set; }

        [BsonElement("cost")] 
        public MoneyDocument Cost { get; set; }

        [BsonElement("pickupDelivery")] 
        public bool PickupDelivery { get; set; }

        public OrderDeliveryDocument() { }

        public OrderDeliveryDocument(
            string deliveryMethodId, 
            string address,
            string pickupPoint,
            MoneyDocument cost, 
            bool pickupDelivery
            )
        {
            DeliveryMethodId = deliveryMethodId;
            Address = address;
            Cost = cost;
            PickupDelivery = pickupDelivery;
            PickupPoint = pickupPoint;
        }
    }
}
