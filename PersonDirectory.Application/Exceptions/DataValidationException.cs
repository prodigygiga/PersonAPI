using System;

namespace PersonDirectory.Application.Exceptions
{
    public abstract class DataValidationException : Exception
    {
        public abstract int StatusCode { get; }
        //public AccountType AccountType { get; }
        //public Guid? AccountId { get; }


        public DataValidationException(string message) : base(message) { }
    }
}
