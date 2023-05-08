namespace ExerciseTracker.Domain.Abstractions;

public interface IGenericService <T>
{
    Task InsertAsync(T entity);
}