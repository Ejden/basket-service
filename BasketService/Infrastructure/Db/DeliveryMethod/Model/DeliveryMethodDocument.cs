using BasketService.Infrastructure.Db.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasketService.Infrastructure.Db.DeliveryMethod.Model
{
    public class DeliveryMethodDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("id")]
        public string Id { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("cost")] 
        public MoneyDocument Cost { get; set; }
        
        [BsonElement("pickupMethod")]
        public bool PickupMethod { get; set; }

        public DeliveryMethodDocument() { }

        public DeliveryMethodDocument(string id, string name, MoneyDocument cost, bool pickupMethod)
        {
            Id = id;
            Name = name;
            Cost = cost;
            PickupMethod = pickupMethod;
        }
    }
}
