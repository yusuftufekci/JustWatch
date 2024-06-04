using JustWatch.Domain.SeedWork;
using JustWatch.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JustWatch.Infrastructure.Repositories
{
    public class JustWatchRepository<T> : IJustWatchRepository<T> where T : BaseJustWatchEntity
    {
        private readonly JustWatchContext _justWatchContext;
        private readonly DbSet<T> _dbSet;
        public JustWatchRepository(JustWatchContext justWatchContext)
        {
            _justWatchContext = justWatchContext;
            _dbSet = _justWatchContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(filter).ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return true;
        }

        public bool Update(T entity)
        {
            _justWatchContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            _dbSet.Remove(entity);
            return true;
        }

        public IQueryable<T> GetAllQuery(Expression<Func<T, bool>> filter = null)
        {
            return _dbSet.Where(filter);
        }

        public async Task<bool> AddManyAsync(List<T> entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entity, cancellationToken);
            return true;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _justWatchContext.SaveChangesAsync(cancellationToken);
        }

        public IQueryable<T> All()
        {
            return _dbSet;
        }

        public bool DeleteAll()
        {
            _dbSet.RemoveRange(_dbSet);
            return true;
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filterExpression, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(filterExpression).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
