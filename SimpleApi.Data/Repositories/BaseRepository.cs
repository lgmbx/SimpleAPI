using Microsoft.EntityFrameworkCore;
using SimpleApi.Data.Context;
using SimpleApi.Domain.Entities;
using SimpleApi.Domain.Interfaces;
using System.Linq.Expressions;

namespace SimpleApi.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;


        protected BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = new T() { Id = id};
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async virtual Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }

        public async virtual Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async virtual Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbSet.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            entities.ToList()
                .ForEach(x => _dbSet.Entry(x).State = EntityState.Modified);
        }
        
        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }
        
    }
}
