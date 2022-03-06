namespace PersonDirectory.Application.Interfaces
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
