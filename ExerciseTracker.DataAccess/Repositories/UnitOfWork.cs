using ExerciseTracker.Domain.Abstractions.Repositories;

namespace ExerciseTracker.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public IUserRepository UserRepository { get; }
    public Task<int> Save()
    {
        throw new NotImplementedException();
    }
}