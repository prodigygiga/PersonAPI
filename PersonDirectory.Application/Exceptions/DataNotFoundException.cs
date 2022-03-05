using System.Net;

namespace PersonDirectory.Application.Exceptions
{
    public class DataNotFoundException : DataValidationException
    {
        public override int StatusCode => (int)HttpStatusCode.NotFound;

        /// <summary>
        /// მოთხოვნილი ჩანაწერი ვერ მოიძებნა
        /// </summary>
        public DataNotFoundException(string message) : base(message) { }
    }
}
