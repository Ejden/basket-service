using System;

namespace BasketService.Infrastructure.Client.Shared
{
    public class ExternalServiceException : Exception
    {
        public ExternalServiceException(string message) : base(message) { }

        public ExternalServiceException() { }
    }
}
