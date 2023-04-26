namespace ExerciseTracker.DataAccess.Abstractions;

public interface IGenericRepository<T>
{
    Task<T> GetById(int id);
    IEnumerable<T> GetAll();
    Task Add(T entity);
    Task Remove(T entity);
}