namespace ExerciseTracker.Domain.Abstractions
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAll();
        void Insert(T entity);
        void Update(T entity);
    }
}
