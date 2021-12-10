using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public class Product
    {
        public ProductId Id { get; }
        
        public string Name { get; }
        
        public int Stock { get; }
        
        public Money Price { get; }

        public Product(ProductId id, string name, int stock, Money price)
        {
            Id = id;
            Name = name;
            Stock = stock;
            Price = price;
        }
    }
}
