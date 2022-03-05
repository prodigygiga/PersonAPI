using System;
using System.Net;

namespace PersonDirectory.Application.Exceptions
{
    public abstract class EntityValidationException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        public EntityValidationException(string message) : base(message) { }
    }
}
