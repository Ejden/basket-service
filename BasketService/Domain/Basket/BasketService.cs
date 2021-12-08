namespace BasketService.Domain.Basket
{
    public class BasketService
    {
        private readonly IBasketProvider _basketProvider;

        public BasketService(IBasketProvider basketProvider)
        {
            _basketProvider = basketProvider;
        }
    }
}
