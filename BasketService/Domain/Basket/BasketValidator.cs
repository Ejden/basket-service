using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Basket.Request;

namespace BasketService.Domain.Basket
{
    public abstract class BasketValidator
    {
        public static void ValidateRequest(AddItemToBasketRequest request)
        {
            ValidateAddingItemQuantity(request.Quantity);
            ValidateNonNullProperty(request.Product.Id);
        }

        public static void ValidateRequest(ModifyItemInBasketRequest request)
        {
            ValidateAddingItemQuantity(request.Quantity);
        }

        private static void ValidateAddingItemQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ValidationException("Item quantity should be grater than 0");
            }
        }

        private static void ValidateNonNullProperty(string property)
        {
            if (property == null)
            {
                throw new ValidationException("Found null in non-nullable field");
            }
        }

        public static void ValidateAddedItem(Product product, AddItemToBasketRequest request)
        {
            ValidateThatProductHasEnoughQuantity(product.Stock, request.Quantity);
        }

        private static void ValidateThatProductHasEnoughQuantity(int actualQuantity, int requestingQuantity)
        {
            if (requestingQuantity > actualQuantity)
            {
                throw new ValidationException("Not enough product quantity");
            }
        }
    }
}
