using System;
using System.Threading.Tasks;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public interface IProductProvider
    {
        public Task<Product> GetProduct(ProductId productId);

        public Task<Product> GetProduct(ProductId productId, DateTime version);

        public Task DecreaseStock(ProductId productId, int amount);
    }
}
