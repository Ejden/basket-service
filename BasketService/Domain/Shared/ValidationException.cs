using System;

namespace BasketService.Domain.Shared
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
