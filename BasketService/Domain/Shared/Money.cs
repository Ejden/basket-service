using System;

namespace BasketService.Domain.Shared
{
    public record Money(decimal Amount, Currency Currency)
    {
        public static Money operator +(Money arg1, Money arg2)
        {
            if (arg1.Currency != arg2.Currency)
            {
                throw new ArgumentException($"Currency mismatch. Expected {arg1}, but was {arg2.Currency}");
            }

            return new Money(arg1.Amount + arg2.Amount, arg1.Currency);
        }

        public static Money operator *(Money arg1, int arg2)
        {
            return new Money(arg1.Amount * arg2, Currency.PLN);
        }

        public static Money Zero(Currency currency)
        {
            return new Money(0.00m, currency);
        }
    }
}
