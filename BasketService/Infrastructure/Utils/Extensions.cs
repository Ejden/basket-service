using BasketService.Domain.Shared;

namespace BasketService.Infrastructure.Utils
{
    public static class Extensions
    {
        public static Money Pln(this decimal amount)
        {
            return new Money(amount, Currency.PLN);
        }
    }
}
