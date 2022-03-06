using Microsoft.EntityFrameworkCore;
using PersonDirectory.Application.Commons;
using PersonDirectory.Application.DTOs;
using PersonDirectory.Application.Interfaces;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;
using System.Data;

namespace PersonDirectory.Infrastructure.Persistence.Implementations.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context)
        {

        }
        private IQueryable<Person> Including =>
        this.context.People
            .Include(x => x.PhoneNumbers)
            .Include(x => x.City)
            .Include(x => x.Relations)
            .ThenInclude(x => x.RelatedPerson)
            .ThenInclude(x => x.PhoneNumbers);

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
            var person = await this.Including.FirstOrDefaultAsync(x => x.Id == id);
            //relations is biDirectional, so added reverted Relations To The Person
            var revertedRelations = context.PersonRelations.Include(x => x.Person).ThenInclude(x => x.PhoneNumbers).Where(x => x.RelatedPersonId == id).ToList();
            foreach (var revRelation in revertedRelations)
            {
                var relation = new PersonRelation(revRelation.RelatedPersonId, person, revRelation.PersonId, revRelation.Person, revRelation.RelationType);
                person.AddRelation(relation);
            }

            return person;
        }

        public Task<List<PersonReportWithRelationsCountDTO>> GetPersonReport()
        {
            using (var cmd = context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = @"
                  select p.Id,p.FirstName,p.LastName,p.PrivateNumber,count(pr.Id) as Amount,pr.RelationType_Id as RelationTypeId from Person.People p
                  left join Person.PersonRelation pr
                  on p.Id = pr.PersonId or p.Id = pr.RelatedPersonId
                  group by p.Id,p.FirstName,p.LastName,PrivateNumber,pr.RelationType_Id,p.DeleteDate,pr.DeleteDate
                  having p.DeleteDate is null and pr.DeleteDate is null

                ";
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 300;

                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                using (var dataReader = cmd.ExecuteReader())
                {
                    var result = Functions.DataReaderMapToList<PersonReportWithRelationsCountDTO>(dataReader);
                    return Task.FromResult(result);
                }
            }
        }

        public async Task<PersonRelation> GetRelationByPersonAndRelatedPersonIdAsync(int personId, int relatedPersonId)
        {
            var relation = await context.PersonRelations.FirstOrDefaultAsync(x => (x.PersonId == personId && x.RelatedPersonId == relatedPersonId) || (x.PersonId == relatedPersonId && x.RelatedPersonId == personId));
            return relation;
        }
    }
}