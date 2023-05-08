namespace ExerciseTracker.Domain.Abstractions
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> InsertAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
