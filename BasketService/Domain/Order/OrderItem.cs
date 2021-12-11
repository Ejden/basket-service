using BasketService.Domain.Shared;

namespace BasketService.Domain.Order
{
    public class OrderItem
    {
        public readonly ProductId ProductId;

        public readonly int Quantity;

        public readonly Money SingleItemCost;

        public readonly Money TotalCost;

        public OrderItem(ProductId productId, int quantity, Money singleItemCost, Money totalCost)
        {
            ProductId = productId;
            Quantity = quantity;
            SingleItemCost = singleItemCost;
            TotalCost = totalCost;
        }
    }
}
