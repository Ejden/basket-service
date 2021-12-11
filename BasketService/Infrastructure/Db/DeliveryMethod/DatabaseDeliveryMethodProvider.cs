using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketService.Domain.DeliveryMethod;
using BasketService.Infrastructure.Db.DeliveryMethod.Config;
using BasketService.Infrastructure.Db.DeliveryMethod.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BasketService.Infrastructure.Db.DeliveryMethod
{
    public class DatabaseDeliveryMethodProvider : IDeliveryMethodProvider
    {
        private readonly IMongoCollection<DeliveryMethodDocument> _deliveryMethodCollection;

        public DatabaseDeliveryMethodProvider(IOptions<DeliveryMethodDatabaseProperties> props)
        {
            var mongoClient = new MongoClient(props.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(props.Value.DatabaseName);
            _deliveryMethodCollection = mongoDb.GetCollection<DeliveryMethodDocument>(props.Value.CollectionName);
        }

        public async Task<ICollection<Domain.DeliveryMethod.DeliveryMethod>> GetAllDeliveryMethods()
        {
            var result = await _deliveryMethodCollection
                .FindAsync(_ => true);

            return result.ToList().Select(DeliveryMethodModelMapper.ToDomain).ToList();
        }

        public async Task<Domain.DeliveryMethod.DeliveryMethod> GetDeliveryMethod(DeliveryMethodId id)
        {
            try
            {
                var result = await _deliveryMethodCollection
                    .FindAsync(it => it.Id == id.Raw);

                return DeliveryMethodModelMapper.ToDomain(result.First());
            }
            catch (InvalidOperationException)
            {
                throw new DeliveryMethodNotFoundException(id);
            }
        }

        public async Task<Domain.DeliveryMethod.DeliveryMethod> CreateDeliveryMethod(Domain.DeliveryMethod.DeliveryMethod deliveryMethod)
        {
            var deliveryMethodDocument = DeliveryMethodModelMapper.ToDocument(deliveryMethod);
            await _deliveryMethodCollection
                .InsertOneAsync(deliveryMethodDocument);

            return await GetDeliveryMethod(DeliveryMethodId.Of(deliveryMethodDocument.Id));
        }

        public async Task<Domain.DeliveryMethod.DeliveryMethod> UpdateDeliveryMethod(Domain.DeliveryMethod.DeliveryMethod deliveryMethod)
        {
            await _deliveryMethodCollection
                .ReplaceOneAsync(
                    it => it.Id == deliveryMethod._id.Raw,
                    DeliveryMethodModelMapper.ToDocument(deliveryMethod)
                );

            return await GetDeliveryMethod(deliveryMethod._id);
        }

        public async Task DeleteDeliveryMethod(DeliveryMethodId id)
        {
            await _deliveryMethodCollection.DeleteOneAsync(it => it.Id == id.Raw);
        }
    }
}
