namespace BasketService.Domain.Shared
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(UserId userId) : base($"User with id {userId.Raw} not found") { }
    }
}
