namespace BasketService.Domain.Order
{
    public record OrderId(string Raw)
    {
        public static OrderId Of(string raw)
        {
            return new OrderId(raw);
        }
    }
}
