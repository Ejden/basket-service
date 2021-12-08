namespace BasketService.Infrastructure.Db.Config
{
    public abstract class DatabaseProperties
    {
        public string ConnectionString { get; }
        
        public string DatabaseName { get; }
        
        public string CollectionName { get; }
    }
}
