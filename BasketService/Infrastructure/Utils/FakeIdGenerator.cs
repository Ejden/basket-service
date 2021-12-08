namespace BasketService.Infrastructure.Utils
{
    public class FakeIdGenerator
    {
        private long _productId = 0L;

        public string GenerateId()
        {
            var newId = _productId;
            _productId++;
            return newId.ToString();
        }
    }
}