namespace BasketService.Infrastructure.Api.Basket.Request
{
    public record AddItemToBasketRequest(AddItemToBasketRequest.ProductRequest Product, int Quantity)
    {
        public record ProductRequest(string Id);
    }
}
