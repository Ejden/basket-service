using System.Collections.Generic;
using BasketService.Domain.Order;
using BasketService.Domain.Shared;
using BasketService.Infrastructure.Db.Order.Config;
using BasketService.Infrastructure.Db.Order.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BasketService.Infrastructure.Db.Order
{
    public class DatabaseOrderProvider : IOrderProvider
    {
        private readonly IMongoCollection<OrderDocument> _orderCollection;
        
        private readonly OrderModelMapper _modelMapper;

        public DatabaseOrderProvider(IOptions<OrderDatabaseProperties> props, OrderModelMapper modelMapper)
        {
            _modelMapper = modelMapper;
            var mongoClient = new MongoClient(props.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(props.Value.DatabaseName);
            _orderCollection = mongoDb.GetCollection<OrderDocument>(props.Value.CollectionName);
        }

        public ICollection<Domain.Order.Order> GetAllOrders()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Domain.Order.Order> GetAllUserOrders(UserId userId)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Order.Order GetOrder(OrderId orderId)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Order.Order Insert(Domain.Order.Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
