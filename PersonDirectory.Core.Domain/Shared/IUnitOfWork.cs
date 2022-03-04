using PersonDirectory.Core.Domain.Interfaces;

namespace Domain.Core.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        public IPersonRepository PersonRepository { get; }
        public ICityRepository CityRepository { get; }
        int Save();
        Task<int> SaveAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
