using Microsoft.EntityFrameworkCore;
using PersonDirectory.Core.Domain.Aggregates.CityAggregate;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;
using PersonDirectory.Core.Domain.Interfaces;

namespace PersonDirectory.Infrastructure.Persistence.Implementations.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DataContext context) : base(context)
        {

        }
       
    }
}