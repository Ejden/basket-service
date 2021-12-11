namespace BasketService.Infrastructure.Db.Shared.Config
{
    public abstract record DatabaseProperties
    {
        public string ConnectionString { get; set; }
        
        public string DatabaseName { get; set; }
        
        public string CollectionName { get; set; }
    }
}
