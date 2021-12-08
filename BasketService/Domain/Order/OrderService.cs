namespace BasketService.Domain.Order
{
    public class OrderService
    {
        private readonly IOrderProvider _orderProvider;

        public OrderService(IOrderProvider orderProvider)
        {
            _orderProvider = orderProvider;
        }
    }
}
