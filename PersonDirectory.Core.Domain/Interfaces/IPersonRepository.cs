using Domain.Core.Shared;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Domain.Interfaces
{
    public interface IPersonRepository:IRepository<Person>
    {
        public Task<Person> GetPersonByIdAsync(int id);
        public Task<PersonRelation> GetRelationByPersonAndRelatedPersonIdAsync(int personId, int relatedPersonId);
        public Task AddRelatedPerson(PersonRelation relation);
        public Task DeleteRelation(PersonRelation relation);

    }
}
