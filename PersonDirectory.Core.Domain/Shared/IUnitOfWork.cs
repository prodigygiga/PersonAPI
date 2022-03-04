using Statements.Core.Domain.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Core.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        public IPersonRepository PersonRepository { get; }
        int Save();
        Task<int> SaveAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
