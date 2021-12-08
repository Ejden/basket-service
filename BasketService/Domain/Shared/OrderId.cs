namespace BasketService.Domain.Shared
{
    public record OrderId(string Raw)
    {
        public static OrderId Of(string raw)
        {
            return new OrderId(raw);
        }
    }
}