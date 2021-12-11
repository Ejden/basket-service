using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public DatabaseOrderProvider(IOptions<OrderDatabaseProperties> props)
        {
            var mongoClient = new MongoClient(props.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(props.Value.DatabaseName);
            _orderCollection = mongoDb.GetCollection<OrderDocument>(props.Value.CollectionName);
        }

        public async Task<ICollection<Domain.Order.Order>> GetAllOrders()
        {
            var result = await _orderCollection
                .FindAsync(_ => true);

            return result.ToList().Select(OrderModelMapper.ToDomain).ToList();
        }

        public async Task<ICollection<Domain.Order.Order>> GetAllUserOrders(UserId userId)
        {
            var result = await _orderCollection
                .FindAsync(it => it.BuyerId == userId.Raw);

            return result.ToList().Select(OrderModelMapper.ToDomain).ToList();
        }

        public async Task<Domain.Order.Order> GetOrder(OrderId orderId)
        {
            var result = await _orderCollection
                .FindAsync(it => it.Id == orderId.Raw);

            return OrderModelMapper.ToDomain(result.First());
        }

        public async Task<Domain.Order.Order> CreateOrder(Domain.Order.Order order)
        {
            await _orderCollection.InsertOneAsync(OrderModelMapper.ToDocument(order));
            return await GetOrder(order.Id);
        }
    }
}
