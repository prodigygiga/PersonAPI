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
       
    }
}