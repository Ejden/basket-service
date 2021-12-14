using System;

namespace BasketService.Domain.Shared
{
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message) { }
    }
}