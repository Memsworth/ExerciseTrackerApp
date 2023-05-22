using ExerciseTracker.Domain.Abstractions.Repositories;

namespace ExerciseTracker.Domain.Abstractions.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IExerciseItemRepository ExerciseItem { get; }
        Task Save();
    }
}
