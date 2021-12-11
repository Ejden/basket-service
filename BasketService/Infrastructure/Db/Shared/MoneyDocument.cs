using System;
using BasketService.Domain.Shared;

namespace BasketService.Infrastructure.Db.Shared
{
    public class MoneyDocument
    {
        public decimal Amount { get; }
        
        public string Currency { get; }

        public MoneyDocument(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money ToDomain()
        {
            return new Money(Amount, Enum.Parse<Currency>(Currency));
        }

        public static MoneyDocument FromDomain(Money money)
        {
            return new MoneyDocument(money.Amount, money.Currency.ToString());
        }
    }
}
