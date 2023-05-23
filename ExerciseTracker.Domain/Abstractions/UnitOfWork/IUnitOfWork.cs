using ExerciseTracker.Domain.Abstractions.Repositories;

namespace ExerciseTracker.Domain.Abstractions.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IExerciseItemRepository ExerciseItemRepository { get; }
        Task CommitAsync();
        Task RollBackAsync();
    }
}
