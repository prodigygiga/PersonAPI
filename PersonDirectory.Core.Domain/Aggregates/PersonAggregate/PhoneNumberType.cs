using Domain.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Domain.Aggregates.PersonAggregate
{
    public class PhoneNumberType : Enumeration
    {
        public static PhoneNumberType Mobile = new(1, nameof(Mobile));
        public static PhoneNumberType Office = new(2, nameof(Office));
        public static PhoneNumberType Home = new(3, nameof(Home));

        public PhoneNumberType(int id, string name)
            : base(id, name)
        {
        }
    }
}
