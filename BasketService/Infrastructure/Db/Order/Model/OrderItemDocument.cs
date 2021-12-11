using BasketService.Domain.Shared;
using BasketService.Infrastructure.Db.Shared;
using MongoDB.Bson.Serialization.Attributes;

namespace BasketService.Infrastructure.Db.Order.Model
{
    public class OrderItemDocument
    {
        [BsonElement("productId")]
        public readonly string ProductId;

        [BsonElement("quantity")]
        public readonly int Quantity;

        [BsonElement("singleItemCost")]
        public readonly MoneyDocument SingleItemCost;

        [BsonElement("totalCost")]
        public readonly MoneyDocument TotalCost;

        public OrderItemDocument(string productId, int quantity, MoneyDocument singleItemCost, MoneyDocument totalCost)
        {
            ProductId = productId;
            Quantity = quantity;
            SingleItemCost = singleItemCost;
            TotalCost = totalCost;
        }
    }
}
