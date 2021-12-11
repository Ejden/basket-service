namespace BasketService.Infrastructure.Client.Shared.Config
{
    public abstract record ClientProperties
    {
        public string ServiceUrl { get; set; }
        
        public string ServicePort { get; set; }
    }
}
