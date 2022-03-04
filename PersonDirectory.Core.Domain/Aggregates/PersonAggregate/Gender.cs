using Domain.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Domain.Aggregates.PersonAggregate
{
    public class Gender : Enumeration
    {
        public static Gender Male = new(1, nameof(Male));
        public static Gender Female = new(2, nameof(Female));

        public Gender(int id, string name)
            : base(id, name)
        {
        }
    }
}
