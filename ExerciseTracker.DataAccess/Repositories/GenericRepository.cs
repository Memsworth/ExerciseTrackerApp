using ExerciseTracker.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccess.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T :  class
{
    protected readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;

    public GenericRepository(ExerciseTrackerDbContext exerciseTrackerDbContext)
    {
        _exerciseTrackerDbContext = exerciseTrackerDbContext;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        try
        {
            return await _exerciseTrackerDbContext.Set<T>().ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    public async Task InsertAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} can't be null");
        }
        try
        {
            await _exerciseTrackerDbContext.AddAsync(entity);
            await _exerciseTrackerDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} can't be null");
        }
        try
        {
            _exerciseTrackerDbContext.Update(entity);
            await _exerciseTrackerDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

}