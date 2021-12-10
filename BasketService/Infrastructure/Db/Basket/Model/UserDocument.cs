using MongoDB.Bson.Serialization.Attributes;

namespace BasketService.Infrastructure.Db.Basket.Model
{
    public class UserDocument
    {
        [BsonElement("id")]
        public string Id { get; set; }

        public UserDocument() { }

        public UserDocument(string id)
        {
            Id = id;
        }
    }
}
