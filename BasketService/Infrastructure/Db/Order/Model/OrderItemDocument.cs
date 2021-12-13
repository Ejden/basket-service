using BasketService.Infrastructure.Db.Shared;
using MongoDB.Bson.Serialization.Attributes;

namespace BasketService.Infrastructure.Db.Order.Model
{
    public class OrderItemDocument
    {
        [BsonElement("productId")]
        public string ProductId { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("singleItemCost")]
        public MoneyDocument SingleItemCost { get; set; }

        [BsonElement("totalCost")]
        public MoneyDocument TotalCost { get; set; }

        public OrderItemDocument() { }

        public OrderItemDocument(string productId, int quantity, MoneyDocument singleItemCost, MoneyDocument totalCost)
        {
            ProductId = productId;
            Quantity = quantity;
            SingleItemCost = singleItemCost;
            TotalCost = totalCost;
        }
    }
}
