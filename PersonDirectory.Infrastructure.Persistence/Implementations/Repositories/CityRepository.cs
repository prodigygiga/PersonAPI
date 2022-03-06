using PersonDirectory.Application.Interfaces;
using PersonDirectory.Core.Domain.Aggregates.CityAggregate;

namespace PersonDirectory.Infrastructure.Persistence.Implementations.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DataContext context) : base(context)
        {

        }
       
    }
}