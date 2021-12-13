using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public class Product
    {
        public readonly ProductId Id;

        public readonly string Name;

        public readonly int Stock;

        public readonly Money Price;

        public Product(ProductId id, string name, int stock, Money price)
        {
            Id = id;
            Name = name;
            Stock = stock;
            Price = price;
        }
    }
}
