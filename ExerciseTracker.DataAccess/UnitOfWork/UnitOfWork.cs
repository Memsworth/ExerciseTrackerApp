using ExerciseTracker.DataAccess.Repositories;
using ExerciseTracker.Domain.Abstractions.Repositories;
using ExerciseTracker.Domain.Abstractions.UnitOfWork;

namespace ExerciseTracker.DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    protected readonly ExerciseTrackerDbContext _dbContext;
    public IExerciseItemRepository ExerciseItemRepository { get; private set;  }

    public UnitOfWork(ExerciseTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
        ExerciseItemRepository = new ExerciseRepository(_dbContext);
    }

    public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

    public async Task RollBackAsync() => await _dbContext.DisposeAsync();       // roll back implies roll back transaction where this actually Disposes of the context which miss leading 

    public void Dispose() => _dbContext.Dispose();

}