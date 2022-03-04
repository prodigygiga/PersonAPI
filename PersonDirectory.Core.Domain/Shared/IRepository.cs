using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Core.Shared
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task Create(TEntity entity);

        TEntity Read(Guid id);
        Task<TEntity> ReadAsync(Guid id);
        Task<List<TEntity>> ReadAsync();
        Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate);

        Task Update(TEntity entity);
        Task Update(Guid id, TEntity entity);

        Task Delete(Guid id);
        Task Delete(TEntity entity);

        Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> CheckAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
