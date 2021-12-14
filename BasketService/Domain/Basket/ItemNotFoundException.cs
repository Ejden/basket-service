using System;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(ProductId productId) : base($"Item with product id {productId} not found") { }
    }
}
