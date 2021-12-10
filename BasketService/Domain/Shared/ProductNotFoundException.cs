namespace BasketService.Domain.Shared
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(ProductId productId) : base($"Product with id {productId.Raw} not found") { }
    }
}
