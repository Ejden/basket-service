using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using BasketService.Domain.Order;
using BasketService.Domain.Order.DetailedOrder;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Basket.Request;
using Microsoft.VisualBasic;

namespace BasketService.Domain.Basket
{
    public class BasketService
    {
        private readonly IBasketProvider _basketProvider;

        private readonly IUserProvider _userProvider;

        private readonly IProductProvider _productProvider;

        private readonly OrderService _orderService;

        public BasketService(
            IBasketProvider basketProvider, 
            IUserProvider userProvider, 
            IProductProvider productProvider,
            OrderService orderService)
        {
            _basketProvider = basketProvider;
            _userProvider = userProvider;
            _productProvider = productProvider;
            _orderService = orderService;
        }

        public async Task<DetailedBasket> GetUserBasket(UserId userId)
        {
            try
            {
                var basket = await _basketProvider.GetUserBasket(userId);
                var products = await Task.WhenAll(
                    basket.Items.Select(it => _productProvider.GetProduct(it.ProductId)));
                return basket.ToDetailed(products);
            }
            catch (BasketNotFoundException)
            {
                var user = await _userProvider.GetUser(userId);  // Just to check that user exists
                var newEmptyBasket = BasketFactory.CreateBasketWithoutItems(userId);
                var basket = await _basketProvider.CreateBasket(newEmptyBasket);
                return basket.ToDetailed(ImmutableArray<Product>.Empty);
            }
        }

        private async Task<Basket> GetSimpleBasket(UserId userId)
        {
            try
            {
                return await _basketProvider.GetUserBasket(userId);
            }
            catch (BasketNotFoundException)
            {
                var user = await _userProvider.GetUser(userId); // Just to check that user exists
                var newEmptyBasket = BasketFactory.CreateBasketWithoutItems(userId);
                return await _basketProvider.CreateBasket(newEmptyBasket);
            }
        }

        public async Task<DetailedOrder> Checkout(UserId userId, CheckoutBasketRequest request)
        {
            var order = await _orderService.CreateOrder(userId, request, await _basketProvider.GetUserBasket(userId));
            await _basketProvider.DeleteUserBasket(userId);
            return order;
        }

        public async Task<Basket> ClearUserBasket(UserId userId)
        {
            await _basketProvider.DeleteUserBasket(userId);
            return await GetSimpleBasket(userId);
        }

        public async Task<Basket> AddItemToBasket(UserId userId, AddItemToBasketRequest request)
        {
            BasketValidator.ValidateRequest(request);
            
            var productToAdd = await _productProvider.GetProduct(ProductId.Of(request.Product.Id));
            var basket = await GetSimpleBasket(userId);
            var updatedBasket = basket.AddItem(new Item(productToAdd.Id, productToAdd.Price, request.Quantity));

            return await _basketProvider.UpdateBasket(updatedBasket);
        }

        public async Task<Basket> ModifyItemInBasket(
            UserId userId, 
            ProductId productId,
            ModifyItemInBasketRequest request)
        {
            BasketValidator.ValidateRequest(request);

            var basketToUpdate = await GetSimpleBasket(userId);
            var updatedItem = basketToUpdate
                .FindItem(productId)
                .ChangeQuantity(request.Quantity);
            var updatedBasket = basketToUpdate.ReplaceItem(productId, updatedItem);
            
            return await _basketProvider.UpdateBasket(updatedBasket);
        }

        public async Task<Basket> RemoveItemFromBasket(UserId userId, ProductId productId)
        {
            var basketToUpdate = await GetSimpleBasket(userId);
            var updatedBasket = basketToUpdate.RemoveItemFromBasket(productId);
            return await _basketProvider.UpdateBasket(updatedBasket);
        }
    }
}
