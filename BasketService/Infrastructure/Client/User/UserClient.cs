﻿using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BasketService.Domain.Basket;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Client.Shared;
using BasketService.Infrastructure.Client.User.Config;
using BasketService.Infrastructure.Client.User.Model;
using Microsoft.Extensions.Options;

namespace BasketService.Infrastructure.Client.User
{
    public class UserClient : IUserProvider
    {
        private static string GET_USER_PATH = "api/user";
        
        private readonly HttpClient _client;
        
        private readonly string _serviceUrl;
        
        public UserClient(HttpClient client, IOptions<UserClientProperties> props)
        {
            _client = client;
            _serviceUrl = $"{props.Value.ServiceUrl}:{props.Value.ServicePort}";
        }

        public async Task<Domain.Shared.User> GetUser(UserId userId)
        {
            try
            {
                var response = await _client.GetAsync(BuildGetUserUri(userId));
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadFromJsonAsync<UserResponse>();
                    return content?.ToDomain() ?? throw new UserNotFoundException(userId);
                }

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new UserNotFoundException(userId);
                }
            }
            catch (HttpRequestException)
            {
                throw new UserServiceException("External service exception");

            }

            throw new UserServiceException("External service exception");
        }
        
        private string BuildGetUserUri(UserId userId)
        {
            return $"{_serviceUrl}/{GET_USER_PATH}/{userId.Raw}";
        }
    }

    public class UserServiceException : ExternalServiceException
    {
        public UserServiceException(string message) : base(message) { }
    }
}
