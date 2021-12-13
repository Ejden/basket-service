using System;
using System.Collections.Immutable;
using System.Linq;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Utils;

namespace BasketService.Domain.Basket
{
    public class Basket
    {
        public readonly BasketId Id;

        public readonly User Buyer;

        public readonly IImmutableList<Item> Items;

        public readonly Money TotalItemsCost;

        public Basket(BasketId basketId, UserId userId, ImmutableList<Item> items)
        {
            Id = basketId;
            Buyer = new User(userId);
            Items = items;
            TotalItemsCost = CalculateTotalItemsCost();
        }

        private Money CalculateTotalItemsCost()
        {
            return Items.Aggregate(0m.Pln(), (money, item) => money + (item.Price * item.Quantity));
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
