using ExerciseTracker.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccess.Repositories;

public class GenericRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;

    public GenericRepository(ExerciseTrackerDbContext exerciseTrackerDbContext)
    {
        _exerciseTrackerDbContext = exerciseTrackerDbContext;
    }


    public async Task<T?> GetById(int id)
    {
        try
        {
            return await _exerciseTrackerDbContext.Set<T>().FindAsync(id);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}. Item with {id} doesn't exist");
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        try
        {
            return await _exerciseTrackerDbContext.Set<T>().ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}. Can't Get items");
        }
    }

    public async Task Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} can't be null");
        }
        try
        {
            await _exerciseTrackerDbContext.Set<T>().AddAsync(entity);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}. Item can't be inserted");
        }
    }

    public async Task Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} can't be null");
        }

        try
        {
            _exerciseTrackerDbContext.Set<T>().Remove(entity);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}. Item can't be deleted");
        }
    }

    public async Task Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} can't be null");
        }

        try
        {
             _exerciseTrackerDbContext.Set<T>().Update(entity);
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}. Item can't be updated");
        }
    }
}