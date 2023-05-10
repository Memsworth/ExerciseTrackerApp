namespace ExerciseTracker.Domain.Abstractions.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }

    Task<int> Save();
}