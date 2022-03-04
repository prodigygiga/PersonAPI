﻿using Domain.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Domain.Aggregates.PersonAggregate
{
    public class PersonRelation:Entity
    {
        public int PersonId { get; private set; }
        public Person Person { get; private set; }
        public int RelatedPersonId { get; private set; }
        public Person RelatedPerson { get; private set; }
        public RelationType RelationType { get; private set; }
        PersonRelation(int personId, int relatedPersonId, RelationType relationType) => (PersonId, RelatedPersonId,RelationType) = (personId,relatedPersonId,relationType);
    }
}
