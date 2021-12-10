using System;
using System.Collections.Immutable;
using System.Linq;
using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public class Basket
    {
        public BasketId Id { get; }
        
        public User Buyer { get; }
        
        public IImmutableList<Item> Items { get; }
        
        public Money TotalItemsCost { get; }

        public Basket(BasketId basketId, UserId userId, ImmutableList<Item> items)
        {
            Id = basketId;
            Buyer = new User(userId);
            Items = items;
            TotalItemsCost = CalculateTotalItemsCost();
        }

        private Money CalculateTotalItemsCost()
        {
            return Items.Aggregate(Money.Zero(Currency.PLN), (money, item) => money + (item.Price * item.Quantity));
        }

        public Basket AddItem(Item item)
        {
            try
            {
                var itemToUpdate = Items.First(it => it.ProductId.Raw == item.ProductId.Raw);
                var updatedItem = itemToUpdate.ChangeQuantity(item.Quantity + itemToUpdate.Quantity);
                return new Basket(
                    Id, 
                    Buyer.UserId, 
                    Items.Where(it => it.ProductId.Raw != item.ProductId.Raw).ToImmutableList().Add(updatedItem)
                );
            }
            catch (InvalidOperationException)
            {
                return new Basket(Id, Buyer.UserId, Items.Add(item).ToImmutableList());
            }
        }

        public Basket ReplaceItem(ProductId productId, Item item)
        {
            var itemToUpdate = Items.First(it => it.ProductId.Raw == productId.Raw);
            return new Basket(
                Id,
                Buyer.UserId,
                Items.Remove(itemToUpdate).Add(item).ToImmutableList()
            );
        }

        public Basket RemoveItemFromBasket(ProductId productId)
        {
            return new Basket(
                Id,
                Buyer.UserId,
                Items.Where(it => it.ProductId.Raw != productId.Raw).ToImmutableList()
            );
        }

        public Item FindItem(ProductId productId)
        {
            try
            {
                return Items.First(it => it.ProductId.Raw == productId.Raw);
            }
            catch (InvalidOperationException)
            {
                throw new ItemNotFoundException(productId);
            }
        }

        public class User
        {
            public UserId UserId { get; }

            public User(UserId userId)
            {
                UserId = userId;
            }
        }
    }
}
