using Microsoft.EntityFrameworkCore;
using SagiCore.Shared.Domain.Repositories;
using System.Linq.Expressions;

namespace SagiCore.Shared.Infrastructure.Persistence
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(TContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(new[] { id }, cancellationToken);
        }

        /// <summary>
        /// Busca entidade por chave composta
        /// </summary>
        public virtual async Task<TEntity?> GetByCompositeKeyAsync(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(keyValues, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.AnyAsync(predicate, cancellationToken);
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
