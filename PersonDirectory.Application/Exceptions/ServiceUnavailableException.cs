using System.Net;

namespace PersonDirectory.Application.Exceptions
{
    public class ServiceUnavailableException : DataValidationException
    {
        public override int StatusCode => (int)HttpStatusCode.ServiceUnavailable;

        public ServiceUnavailableException(string message) : base(message) { }
    }
}
