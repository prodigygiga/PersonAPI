using Domain.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Domain.Aggregates.PersonAggregate
{
    public class PhoneNumber : Entity
    {
        public string Number { get; private set; }
        public PhoneNumberType PhoneNumberType { get; private set; }
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        protected PhoneNumber() { }
        public PhoneNumber(string number, PhoneNumberType phoneNumberType,int personId) =>(Number,PhoneNumberType,PersonId) = (number, phoneNumberType,personId);
    }
}
