using SimpleApi.Domain.Entities;
using System.Linq.Expressions;

namespace SimpleApi.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : Entity
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        
        void Delete(T entity);
        void Delete(int id);
        void DeleteRange(IEnumerable<T> entities);

        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> predicate);

    }
}
