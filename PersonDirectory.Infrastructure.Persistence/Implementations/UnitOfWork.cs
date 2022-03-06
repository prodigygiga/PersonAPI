using PersonDirectory.Application.Interfaces;
using PersonDirectory.Infrastructure.Persistence.Implementations.Repositories;

namespace PersonDirectory.Infrastructure.Persistence.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICityRepository cityRepository;
        private IPersonRepository personRepository;

        private readonly DataContext context;
        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }
        public ICityRepository CityRepository => cityRepository ??= new CityRepository(context);
        public IPersonRepository PersonRepository => personRepository ??= new PersonRepository(context);
        public int Save() => context.SaveChanges();
        public async Task<int> SaveAsync() => await context.SaveChangesAsync();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
