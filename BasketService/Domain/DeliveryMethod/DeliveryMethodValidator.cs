using System;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.DeliveryMethod.Request;
using BasketService.Infrastructure.Api.Shared;

namespace BasketService.Domain.DeliveryMethod
{
    public abstract class DeliveryMethodValidator
    {
        public static void ValidateCreateRequest(CreateDeliveryMethodRequest request)
        {
            ValidateNonNullProperty(request.Name);
            ValidateNonNullProperty(request.Cost);
            ValidateCost(request.Cost);
        }

        public static void ValidateModifyRequest(ModifyDeliveryMethodRequest request)
        {
            ValidateNonNullProperty(request.Name);
            ValidateNonNullProperty(request.Cost);
            ValidateCost(request.Cost);
        }

        private static void ValidateCost(MoneyDto money)
        {
            ValidatePriceAmount(money.Amount);
            ValidatePriceCurrency(money.Currency);
        }
        
        private static void ValidatePriceAmount(decimal amount)
        {
            if (amount < 0.00m)
            {
                throw new ValidationException("Price should be grater or equal 0.00");
            }
        }

        private static void ValidatePriceCurrency(string currency)
        {
            var successful = Enum.TryParse(currency, out Currency ca);
            if (!successful)
            {
                throw new ValidationException("Unsupported currency");
            }
        }

        private static void ValidatePropertyLength(string property)
        {
            if (property.Trim().Length < 0)
            {
                throw new ValidationException("Text length should be grater than 0");
            }
        }
        
        private static void ValidateNonNullProperty(object property)
        {
            if (property == null)
            {
                throw new ValidationException("Found null in non-nullable field");
            }
        }
    }
}
