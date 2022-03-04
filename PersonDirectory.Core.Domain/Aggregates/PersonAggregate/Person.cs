using Domain.Core.Shared;
using PersonDirectory.Core.Domain.Aggregates.CityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Domain.Aggregates.PersonAggregate
{
    public class Person : Entity, IAggregateRoot
    {
        private readonly HashSet<PhoneNumber> phoneNumbers;
        private readonly HashSet<PersonRelation> relations;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PrivateNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int CityId { get; private set; }
        public City City { get; private set; }
        public string PicturePath { get; private set; }
        public IReadOnlyCollection<PhoneNumber> PhoneNumbers => phoneNumbers;
        public IReadOnlyCollection<PersonRelation> Relations => relations;
    }
}
