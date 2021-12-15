using System.Collections.Immutable;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public class DetailedBasket
    {
        public readonly BasketId Id;

        public readonly Basket.User Buyer;

        public readonly IImmutableList<DetailedItem> Items;

        public readonly Money TotalItemsCost;

        public DetailedBasket(BasketId id, Basket.User buyer, IImmutableList<DetailedItem> items, Money totalItemsCost)
        {
            Id = id;
            Buyer = buyer;
            Items = items;
            TotalItemsCost = totalItemsCost;
        }
    }
    
    public class DetailedItem : Item
    {
        public readonly string Name;

        public DetailedItem(ProductId productId, Money price, int quantity, string name) : base(productId, price, quantity)
        {
            Name = name;
        }
    }
}