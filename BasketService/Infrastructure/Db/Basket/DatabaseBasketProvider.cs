using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketService.Domain.Basket;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Db.Basket.Config;
using BasketService.Infrastructure.Db.Basket.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BasketService.Infrastructure.Db.Basket
{
    public class DatabaseBasketProvider : IBasketProvider
    {
        private readonly IMongoCollection<BasketDocument> _basketCollection;

        public DatabaseBasketProvider(IOptions<BasketDatabaseProperties> props)
        {
            var mongoClient = new MongoClient(props.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(props.Value.DatabaseName);
            _basketCollection = mongoDb.GetCollection<BasketDocument>(props.Value.CollectionName);
        }

        public async Task<ICollection<Domain.Basket.Basket>> GetAllBaskets()
        {
            var result = await _basketCollection
                .FindAsync(_ => true);

            return result.ToList().Select(BasketModelMapper.ToDomain).ToList();
        }

        public async Task<Domain.Basket.Basket> GetUserBasket(UserId userId)
        {
            try
            {
                var result = await _basketCollection
                    .FindAsync(it => it.Buyer.Id == userId.Raw);

                return BasketModelMapper.ToDomain(result.First());
            }
            catch (InvalidOperationException)
            {
                throw new BasketNotFoundException(userId);
            }
        }

        public async void DeleteUserBasket(UserId userId)
        {
            await _basketCollection.DeleteOneAsync(it => it.Buyer.Id == userId.Raw);
        }

        public async Task<Domain.Basket.Basket> CreateBasket(Domain.Basket.Basket basket)
        {
            await _basketCollection.InsertOneAsync(BasketModelMapper.ToDocument(basket));
            return await GetUserBasket(basket.Buyer.UserId);
        }

        public async Task<Domain.Basket.Basket> UpdateBasket(Domain.Basket.Basket basket)
        {
            await _basketCollection.ReplaceOneAsync(
                it => it.Id == basket.Id.Raw, 
                BasketModelMapper.ToDocument(basket)
            );
            return await GetUserBasket(basket.Buyer.UserId);
        }
    }
}
