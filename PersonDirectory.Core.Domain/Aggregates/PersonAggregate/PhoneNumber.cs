using Domain.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Domain.Aggregates.PersonAggregate
{
    public class PhoneNumber : ValueObject
    {
        public string Number { get; private set; }
        public PhoneNumberType PhoneNumberType { get; private set; }
        public PhoneNumber(string number, PhoneNumberType phoneNumberType) =>(Number,PhoneNumberType) = (number, phoneNumberType);
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
            yield return PhoneNumberType;
        }
    }
}
