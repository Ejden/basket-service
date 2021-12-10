using System.Threading.Tasks;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Basket.Request;

namespace BasketService.Domain.Basket
{
    public class BasketService
    {
        private readonly IBasketProvider _basketProvider;

        private readonly IUserProvider _userProvider;

        private readonly IProductProvider _productProvider;

        public BasketService(IBasketProvider basketProvider, IUserProvider userProvider, IProductProvider productProvider)
        {
            _basketProvider = basketProvider;
            _userProvider = userProvider;
            _productProvider = productProvider;
        }

        public async Task<Basket> GetUserBasket(UserId userId)
        {
            try
            {
                return await _basketProvider.GetUserBasket(userId);
            }
            catch (BasketNotFoundException)
            {
                var user = _userProvider.GetUser(userId);  // Just to check that user exists
                var newEmptyBasket = BasketFactory.CreateBasketWithoutItems(userId);
                return await _basketProvider.Create(newEmptyBasket);
            }
        }

        public async Task<Basket> ClearUserBasket(UserId userId)
        {
            _basketProvider.DeleteUserBasket(userId);
            return await GetUserBasket(userId);
        }

        public async Task<Basket> AddItemToBasket(UserId userId, AddItemToBasketRequest request)
        {
            BasketValidator.ValidateRequest(request);
            
            var productToAdd = await _productProvider.GetProduct(ProductId.Of(request.Product.Id));
            var basket = await GetUserBasket(userId);
            var updatedBasket = basket.AddItem(new Item(productToAdd.Id, productToAdd.Price, request.Quantity));

            return await _basketProvider.Update(updatedBasket);
        }

        public async Task<Basket> ModifyItemInBasket(
            UserId userId, 
            ProductId productId,
            ModifyItemInBasketRequest request)
        {
            BasketValidator.ValidateRequest(request);

            var basketToUpdate = await GetUserBasket(userId);
            var updatedItem = basketToUpdate
                .FindItem(productId)
                .ChangeQuantity(request.Quantity);
            var updatedBasket = basketToUpdate.ReplaceItem(productId, updatedItem);
            
            return await _basketProvider.Update(updatedBasket);
        }

        public async Task<Basket> RemoveItemFromBasket(UserId userId, ProductId productId)
        {
            var basketToUpdate = await GetUserBasket(userId);
            var updatedBasket = basketToUpdate.RemoveItemFromBasket(productId);
            return await _basketProvider.Update(updatedBasket);
        }
    }
}
