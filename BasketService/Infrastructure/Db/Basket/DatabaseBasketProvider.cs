using System.Collections.Generic;
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
        private readonly BasketModelMapper _modelMapper;

        public DatabaseBasketProvider(IOptions<BasketDatabaseProperties> props, BasketModelMapper modelMapper)
        {
            _modelMapper = modelMapper;
            var mongoClient = new MongoClient(props.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(props.Value.DatabaseName);
            _basketCollection = mongoDb.GetCollection<BasketDocument>(props.Value.CollectionName);
        }

        public ICollection<Domain.Basket.Basket> GetAllBaskets()
        {
            throw new System.NotImplementedException();
        }

        public Domain.Basket.Basket GetUserBasket(UserId userId)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Basket.Basket Create(Domain.Basket.Basket basket)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Basket.Basket Update(Domain.Basket.Basket basket)
        {
            throw new System.NotImplementedException();
        }
    }
}
