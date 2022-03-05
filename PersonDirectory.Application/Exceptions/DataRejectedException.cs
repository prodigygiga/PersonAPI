using System.Net;

namespace PersonDirectory.Application.Exceptions
{
    public class DataRejectedException : DataValidationException
    {
        public override int StatusCode => (int)HttpStatusCode.NotAcceptable;

        /// <summary>
        /// მსგავსი მონაცემის არსებობა ბაზაში აკრძალულია
        /// მსგავსი მოქმედება აკრძალულია
        /// </summary>
        public DataRejectedException(string message) : base(message) { }
    }
}
