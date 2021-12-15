using System;
using System.Collections.Generic;
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
        
        private readonly Func<ProductId, ProductId, bool> _equalsIdsPredicate = delegate(ProductId arg1, ProductId arg2)
        {
            return arg1 == arg2;
        };
        
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
                var itemToUpdate = Items.First(it => _equalsIdsPredicate(it.ProductId, item.ProductId));
                var updatedItem = itemToUpdate.ChangeQuantity(item.Quantity + itemToUpdate.Quantity);
                return new Basket(
                    Id, 
                    Buyer.UserId, 
                    Items.Where(it => it.ProductId != item.ProductId).ToImmutableList().Add(updatedItem)
                );
            }
            catch (InvalidOperationException)
            {
                return new Basket(Id, Buyer.UserId, Items.Add(item).ToImmutableList());
            }
        }

        public Basket ReplaceItem(ProductId productId, Item item)
        {
            var itemToUpdate = Items.First(it => it.ProductId == productId);
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
                Items.Where(it => it.ProductId != productId).ToImmutableList()
            );
        }

        public Item FindItem(ProductId productId)
        {
            try
            {
                return Items.First(it => it.ProductId == productId);
            }
            catch (InvalidOperationException)
            {
                throw new ItemNotFoundException(productId);
            }
        }

        public DetailedBasket ToDetailed(ICollection<Product> products)
        {
            return new DetailedBasket(
                Id,
                Buyer,
                Items.Select(it => new DetailedItem(
                    it.ProductId, 
                    it.Price, 
                    it.Quantity, 
                    products.First(product => product.Id == it.ProductId).Name
                )).ToImmutableList(),
                TotalItemsCost
            );
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
