using System.Net;

namespace PersonDirectory.Application.Exceptions
{
    public class DefectiveDataException : DataValidationException
    {
        public override int StatusCode => (int)HttpStatusCode.UnprocessableEntity;

        /// <summary>
        /// ბაზაში აღმოჩენილია დეფექტური ჩანაწერი
        /// </summary>
        public DefectiveDataException(string message) : base(message) { }
    }
}
