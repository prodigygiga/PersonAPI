using Domain.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Domain.Aggregates.PersonAggregate
{
    public class RelationType : Enumeration
    {
        public static RelationType Colleague = new(1, nameof(Colleague));
        public static RelationType Familiar = new(2, nameof(Familiar));
        public static RelationType Relative = new(3, nameof(Relative));
        public static RelationType Other = new(0, nameof(Other));

        public RelationType(int id, string name)
            : base(id, name)
        {
        }
    }
}
