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
    }
}
