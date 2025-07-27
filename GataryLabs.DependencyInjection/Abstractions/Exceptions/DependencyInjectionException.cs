using System;

namespace GataryLabs.DependencyInjection.Abstractions.Exceptions
{
    public class DependencyInjectionException : Exception
    {
        public DependencyInjectionException(string message) : base(message)
        {
        }

        public DependencyInjectionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
