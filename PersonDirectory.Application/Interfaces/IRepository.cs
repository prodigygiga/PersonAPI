using Domain.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task Create(TEntity entity);
        TEntity Read(int id);
        Task<TEntity> ReadAsync(int id);
        Task<List<TEntity>> ReadAsync();
        Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate);

        Task Update(TEntity entity);
        Task Update(int id, TEntity entity);

        Task Delete(int id);
        Task Delete(TEntity entity);

        Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> CheckAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
