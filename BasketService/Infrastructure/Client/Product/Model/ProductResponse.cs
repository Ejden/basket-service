using System;
using BasketService.Domain.Shared;

namespace BasketService.Infrastructure.Client.Product.Model
{
    public class ProductResponse
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Version { get; set; }
        
        public int Stock { get; set; }
        
        public PriceResponse Price { get; set; }

        public Domain.Basket.Product ToDomain()
        {
            return new Domain.Basket.Product(
                ProductId.Of(Id),
                Name,
                Stock,
                new Money(Price.Amount, Enum.Parse<Currency>(Price.Currency))
            );
        }
    }
}
