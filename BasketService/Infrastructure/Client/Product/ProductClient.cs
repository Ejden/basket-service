using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BasketService.Domain.Basket;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Client.Product.Config;
using BasketService.Infrastructure.Client.Product.Model;
using BasketService.Infrastructure.Client.Shared;
using Microsoft.Extensions.Options;

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

        public async Task<Domain.Basket.Product> GetProduct(ProductId productId, DateTime version)
        {
            var response = await _client.GetAsync(BuildGetProductUri(productId, version));

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

        public async Task DecreaseStock(ProductId productId, int amount)
        {
            try
            {
                var body = JsonSerializer.Serialize(new DecreaseQuantityBody(amount));
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                await _client.PostAsync(BuildDecreaseProductStockUri(productId), content);
            }
            catch (Exception)
            {
                throw new ProductServiceException("Can't decrease product stock");
            }
        }

        private string BuildGetProductUri(ProductId productId)
        {
            return $"{_serviceUrl}/{GET_PRODUCT_PATH}/{productId.Raw}";
        }
        
        private string BuildGetProductUri(ProductId productId, DateTime version)
        {
            return $"{_serviceUrl}/{GET_PRODUCT_PATH}/{productId.Raw}?version={version}";
        }

        private string BuildDecreaseProductStockUri(ProductId productId)
        {
            return $"{_serviceUrl}/products/{productId.Raw}/stock";
        }

        private class DecreaseQuantityBody
        {
            [JsonPropertyName("decreaseBy")]
            public  int DecreaseBy { get; set; }

            public DecreaseQuantityBody() { }

            public DecreaseQuantityBody(int decreaseBy)
            {
                DecreaseBy = decreaseBy;
            }
        }
    }

    public class ProductServiceException : ExternalServiceException
    {
        public ProductServiceException(string message) : base(message) { }
    }
}
