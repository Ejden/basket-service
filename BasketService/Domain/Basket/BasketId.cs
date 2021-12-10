namespace BasketService.Domain.Basket
{
    public record BasketId(string Raw)
    {
        public static BasketId Of(string raw)
        {
            return new BasketId(raw);
        }
    }
}
