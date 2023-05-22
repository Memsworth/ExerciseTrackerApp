using System.Linq.Expressions;

namespace ExerciseTracker.Domain.Abstractions.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
