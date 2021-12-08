namespace BasketService.Domain.Shared
{
    public record ProductId(string Raw)
    {
        public static ProductId Of(string raw)
        {
            return new ProductId(raw);
        }
    }
}