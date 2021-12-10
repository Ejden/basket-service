using System.Threading.Tasks;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public interface IProductProvider
    {
        public Task<Product> GetProduct(ProductId productId);
    }
}
