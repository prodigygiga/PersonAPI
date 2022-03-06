using Domain.Core.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonDirectory.Infrastructure.Persistence.Implementations
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public virtual Task Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return Task.CompletedTask;
        }
        // read block
        #region Read
        public virtual TEntity Read(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
        public virtual async Task<TEntity> ReadAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        public virtual async Task<List<TEntity>> ReadAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        #endregion
        // update block
        #region Update
        public virtual Task Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }
        public virtual Task Update(int id, TEntity entity)
        {
            var existing = context.Set<TEntity>().Find(id);
            this.context.Entry(existing).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }
        #endregion
        // delete block
        #region Delete
        public virtual Task Delete(int id)
        {
            context.Set<TEntity>().Remove(this.Read(id));
            return Task.CompletedTask;
        }
        public virtual Task Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }
        #endregion
        // check block
        #region Check
        public virtual async Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().AnyAsync(predicate);
        }
        public virtual async Task<bool> CheckAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().AllAsync(predicate);
        } 
        #endregion

    }
}