using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasketService.Domain.Basket;
using BasketService.Domain.DeliveryMethod;
using BasketService.Domain.Order.DetailedOrder;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Basket.Request;
using BasketService.Infrastructure.Utils;

namespace BasketService.Domain.Order
{
    public class OrderFactory
    {
        private readonly IProductProvider _productProvider;

        private readonly IDeliveryMethodProvider _deliveryMethodProvider;

        private readonly IUserProvider _userProvider;

        private readonly Regex _pickupCodeRegex = new Regex("^[A-Z]{3}[0-9]{4}$");
        
        public OrderFactory(
            IProductProvider productProvider, 
            IDeliveryMethodProvider deliveryMethodProvider, 
            IUserProvider userProvider)
        {
            _productProvider = productProvider;
            _deliveryMethodProvider = deliveryMethodProvider;
            _userProvider = userProvider;
        }

        public async Task<Order> CreateOrder(UserId userId, CheckoutBasketRequest request, Basket.Basket basket)
        {
            var userFuture = _userProvider.GetUser(userId);
            var deliveryMethodFuture = _deliveryMethodProvider
                .GetDeliveryMethod(DeliveryMethodId.Of(request.DeliveryMethodId));
            var productsFuture = basket.Items.Select(it => _productProvider.GetProduct(it.ProductId));
            var products = await Task.WhenAll(productsFuture);
            var user = await userFuture;
            var deliveryMethod = await deliveryMethodFuture;
            if (deliveryMethod.PickupMethod)
            {
                request.ValidatePickupCode(_pickupCodeRegex);
            }

            basket.ValidateProductsQuantity(products);
            
            await Task.WhenAll(basket.Items.Select(it => _productProvider.DecreaseStock(it.ProductId, it.Quantity)));
            
            return new Order(
                OrderId.Of(Guid.NewGuid().ToString()),
                new Buyer(userId),
                DateTime.Now,
                basket.Items.Select(it => new OrderItem(
                    it.ProductId, 
                    it.Quantity, 
                    it.Price, 
                    it.Price * it.Quantity)
                ).ToImmutableList(),
                CreateDelivery(
                    deliveryMethod, 
                    request.DeliveryAddress, 
                    user
                ),
                CalculateTotalCost(user, deliveryMethod, basket)
            );
        }

        private OrderDelivery CreateDelivery(DeliveryMethod.DeliveryMethod deliveryMethod, string address, User user)
        {
            if (deliveryMethod.PickupMethod)
            {
                return new PickupPointOrderDelivery(
                    deliveryMethod.Id,
                    address,
                    CalculateDeliveryCost(user, deliveryMethod)
                );
            }

            return new AddressOrderDelivery(
                deliveryMethod.Id,
                address,
                CalculateDeliveryCost(user, deliveryMethod)
            );
        }

        private Money CalculateTotalCost(User user, DeliveryMethod.DeliveryMethod deliveryMethod, Basket.Basket basket)
        {
            return CalculateDeliveryCost(user, deliveryMethod) + CalculateTotalProductsCost(basket);
        }

        private Money CalculateDeliveryCost(User user, DeliveryMethod.DeliveryMethod deliveryMethod)
        {
            return user.IsFreeDeliveryActive ? 0.00m.Pln() : deliveryMethod.Cost;
        }

        private Money CalculateTotalProductsCost(Basket.Basket basket)
        {
            return basket.Items.Aggregate(0.00m.Pln(), (money, item) => money + (item.Price * item.Quantity));
        }

        public async Task<ICollection<DetailedOrder.DetailedOrder>> ToDetailedOrders(ICollection<Order> orders)
        {
            var detailedOrdersFuture = orders.Select(ToDetailedOrder);
            return await Task.WhenAll(detailedOrdersFuture);
        }

        public async Task<DetailedOrder.DetailedOrder> ToDetailedOrder(Order order)
        {
            var productsFuture = order.Items
                .Select(it => _productProvider.GetProduct(it.ProductId, order.OrderTimestamp));
            var deliveryMethodFuture = _deliveryMethodProvider
                .GetDeliveryMethod(order.Delivery.DeliveryMethodId);
            
            var products = await Task.WhenAll(productsFuture);
            var deliveryMethod = await deliveryMethodFuture;

            return new DetailedOrder.DetailedOrder(
                order.Id,
                order.Buyer,
                order.OrderTimestamp,
                order.Items.Select(it => ToDetailed(it, products)).ToImmutableList(),
                CreateDetailedDelivery(
                    deliveryMethod,
                    order.Delivery
                ),
                order.TotalCost
            );
        }

        private DetailedOrderDelivery CreateDetailedDelivery(
            DeliveryMethod.DeliveryMethod deliveryMethod, 
            OrderDelivery orderDelivery)
        {
            return orderDelivery switch
            {
                AddressOrderDelivery addressOrderDelivery => new DetailedAddressOrderDelivery(
                    new DetailedDeliveryMethod(addressOrderDelivery.DeliveryMethodId, deliveryMethod.Name),
                    addressOrderDelivery.Address, addressOrderDelivery.Cost),
                PickupPointOrderDelivery pickupPointOrderDelivery => new DetailedPickupPointOrderDelivery(
                    new DetailedDeliveryMethod(pickupPointOrderDelivery.DeliveryMethodId, deliveryMethod.Name),
                    pickupPointOrderDelivery.PickupPoint, pickupPointOrderDelivery.Cost),
                _ => throw new ServiceException("Service error")
            };
        }

        private DetailedOrderItem ToDetailed(OrderItem item, Product[] products)
        {
            var correspondingProduct = products.First(it => it.Id.Raw == item.ProductId.Raw);

            return new DetailedOrderItem(
                correspondingProduct.Id,
                correspondingProduct.Name,
                item.Quantity,
                item.SingleItemCost,
                item.TotalCost
            );
        }
    }
    
    public static class Extensions
    {
        public static Basket.Basket ValidateProductsQuantity(this Basket.Basket basket, ICollection<Product> products)
        {
            var fulfillsQuantity = basket.Items
                .All(it => products.First(p => p.Id.Raw == it.ProductId.Raw).Stock >= it.Quantity);
            if (fulfillsQuantity)
            {
                return basket;
            }
            
            throw new ValidationException("Can't order more than product stock");
        }

        public static CheckoutBasketRequest ValidatePickupCode(this CheckoutBasketRequest request, Regex regex)
        {
            if (!regex.IsMatch(request.DeliveryAddress))
            {
                throw new ValidationException("Wrong pickup code");
            }

            return request;
        }
    }
}
