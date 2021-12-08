namespace BasketService.Domain.Shared
{
    public record UserId(string Raw)
    {
        public static UserId Of(string raw)
        {
            return new UserId(raw);
        }
    }
}