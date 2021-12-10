using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public class Item
    {
        public ProductId ProductId { get; }

        public Money Price { get; }

        public int Quantity { get; }

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
