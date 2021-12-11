using System;
using BasketService.Domain.Shared;

namespace BasketService.Infrastructure.Api.Shared
{
    public record MoneyDto(decimal Amount, string Currency)
    {
        public static MoneyDto FromDomain(Money money)
        {
            return new MoneyDto(money.Amount, money.Currency.ToString());
        }

        public Money ToDomain()
        {
            return new Money(Amount, Enum.Parse<Currency>(Currency));
        }
    }
}
