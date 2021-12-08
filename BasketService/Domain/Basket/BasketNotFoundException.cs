using BasketService.Domain.Shared;

namespace BasketService.Domain.Basket
{
    public class BasketNotFoundException : NotFoundException
    {
        public BasketNotFoundException(UserId userId) : base($"Basket for user with id {userId} not found") { }
    }
}
