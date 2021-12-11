namespace BasketService.Domain.DeliveryMethod
{
    public record DeliveryMethodId(string Raw)
    {
        public static DeliveryMethodId Of(string raw)
        {
            return new DeliveryMethodId(raw);
        }
    }
}
