using BasketService.Infrastructure.Db.Shared;
using MongoDB.Bson.Serialization.Attributes;

namespace BasketService.Infrastructure.Db.Basket.Model
{
    public class ItemDocument
    {
        [BsonElement("productId")]
        public string ProductId { get; set; }
        
        [BsonElement("price")]
        public MoneyDocument Price { get; set; }
        
        [BsonElement("quantity")]
        public int Quantity { get; set; }

        public ItemDocument() { }

        public ItemDocument(string productId, MoneyDocument price, int quantity)
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }
    }
}
