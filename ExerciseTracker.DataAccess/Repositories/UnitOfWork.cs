using ExerciseTracker.Domain.Abstractions.Repositories;

namespace ExerciseTracker.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected readonly ExerciseTrackerDbContext _exerciseTrackerDbContext;
    public IUserRepository UserRepository { get; }

    public UnitOfWork(ExerciseTrackerDbContext exerciseTrackerDbContext, IUserRepository userRepository)
    {
        _exerciseTrackerDbContext = exerciseTrackerDbContext;
        UserRepository = userRepository;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async Task<int> Save()
    {
        return await _exerciseTrackerDbContext.SaveChangesAsync();
    }
}