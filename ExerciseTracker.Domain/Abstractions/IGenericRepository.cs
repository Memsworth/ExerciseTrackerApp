namespace ExerciseTracker.Domain.Abstractions
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
