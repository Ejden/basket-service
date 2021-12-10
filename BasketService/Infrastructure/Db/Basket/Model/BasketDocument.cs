using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BasketService.Infrastructure.Db.Basket.Model
{
    public class BasketDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("buyer")]
        public UserDocument Buyer { get; set; }

        [BsonElement("items")]
        public List<ItemDocument> Items { get; set; }
        
        public BasketDocument() { }

        public BasketDocument(string id, UserDocument buyer, List<ItemDocument> items)
        {
            Id = id;
            Buyer = buyer;
            Items = items;
        }
    }
}
