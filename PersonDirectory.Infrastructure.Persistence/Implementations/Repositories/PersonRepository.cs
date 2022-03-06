using Microsoft.EntityFrameworkCore;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;
using PersonDirectory.Core.Domain.Interfaces;

namespace PersonDirectory.Infrastructure.Persistence.Implementations.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context)
        {

        }
        private IQueryable<Person> Including =>
        this.context.People
            .Include(x => x.PhoneNumbers);

        public Task AddRelatedPerson(PersonRelation relation)
        {
            context.PersonRelations.Add(relation);
            return Task.CompletedTask;
        }

        public Task DeleteRelation(PersonRelation relation)
        {
            context.PersonRelations.Update(relation);
            return Task.CompletedTask;
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            var person = await this.Including.FirstOrDefaultAsync(x => x.Id == id && x.DeleteDate == null);
            return person;
        }

        public async Task<PersonRelation> GetRelationByPersonAndRelatedPersonIdAsync(int personId, int relatedPersonId)
        {
            var relation = await context.PersonRelations.FirstOrDefaultAsync(x => x.PersonId == personId && x.RelatedPersonId == relatedPersonId && x.DeleteDate == null);
            return relation;
        }
    }
}