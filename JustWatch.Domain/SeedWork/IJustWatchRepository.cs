using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JustWatch.Domain.SeedWork
{
    public interface IJustWatchRepository<TEntity> where TEntity : BaseJustWatchEntity
    {
        Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<bool> AddManyAsync(List<TEntity> entity, CancellationToken cancellationToken = default);
        bool Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetAllQuery(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        IQueryable<TEntity> All();
        bool DeleteAll();
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filterExpression, CancellationToken cancellationToken = default);

    }
}
