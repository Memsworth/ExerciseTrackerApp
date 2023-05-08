using ExerciseTracker.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccess.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T :  class
{
    protected readonly ExerciseTrackerDbContext ExerciseTrackerDbContext;

    public GenericRepository(ExerciseTrackerDbContext exerciseTrackerDbContext)
    {
        ExerciseTrackerDbContext = exerciseTrackerDbContext;
    }

    public async Task<List<T>> GetAll()
    {
        try
        {
            return await ExerciseTrackerDbContext.Set<T>().ToListAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    public async void Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} can't be null");
        }
        try
        {
            await ExerciseTrackerDbContext.AddAsync(entity);
            await ExerciseTrackerDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

    public async void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} can't be null");
        }
        try
        {
            ExerciseTrackerDbContext.Update(entity);
            await ExerciseTrackerDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}");
        }
    }

}