using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public class Item
    {
        public readonly ProductId ProductId;

        public readonly Money Price;

        public readonly int Quantity;

        public Item(ProductId productId, Money price, int quantity)
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public Item ChangeQuantity(int newQuantity)
        {
            return new Item(ProductId, Price, newQuantity);
        }
    }
}
