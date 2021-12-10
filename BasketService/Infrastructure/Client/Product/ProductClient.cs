using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BasketService.Domain.Basket;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Api.Basket.Config;
using BasketService.Infrastructure.Client.Product.Model;
using Microsoft.Extensions.Options;
using ApplicationException = System.ApplicationException;

namespace BasketService.Infrastructure.Client.Product
{
    public class ProductClient : IProductProvider
    {
        private static string GET_PRODUCT_PATH = "products";
        
        private readonly HttpClient _client;
        
        private readonly string _serviceUrl;

        public ProductClient(HttpClient client, IOptions<ProductClientProperties> props)
        {
            _client = client;
            _serviceUrl = $"{props.Value.ServiceUrl}:{props.Value.ServicePort}";
        }

        public async Task<Domain.Basket.Product> GetProduct(ProductId productId)
        {
            var response = await _client.GetAsync(BuildGetProductUri(productId));
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<ProductResponse>().Result?.ToDomain() ??
                       throw new ProductNotFoundException(productId);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ProductNotFoundException(productId);
            }

            throw new ProductServiceException("External service exception");
        }

        private string BuildGetProductUri(ProductId productId)
        {
            return $"{_serviceUrl}/{GET_PRODUCT_PATH}/{productId.Raw}";
        }
    }

    public class ProductServiceException : Exception
    {
        public ProductServiceException(string message) : base(message) { }
    }
}
