using BasketService.Domain.Shared;

namespace BasketService.Domain.Order.DetailedOrder
{
    public class DetailedOrderItem
    {
        public readonly ProductId ProductId;

        public readonly string Name;
        
        public readonly int Quantity;

        public readonly Money SingleItemCost;

        public readonly Money TotalCost;

        public DetailedOrderItem(ProductId productId, string name, int quantity, Money singleItemCost, Money totalCost)
        {
            ProductId = productId;
            Name = name;
            Quantity = quantity;
            SingleItemCost = singleItemCost;
            TotalCost = totalCost;
        }
    }
}
