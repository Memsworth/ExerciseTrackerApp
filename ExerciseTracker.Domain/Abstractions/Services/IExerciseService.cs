using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Domain.Abstractions.Services;

public interface IExerciseService
{
    Task<ExerciseItem> GetExerciseByIdAsync(int id);
    Task<List<ExerciseItem>> GetAllExerciseAsync();
    Task AddExerciseAsync(ExerciseItem exercise);
    Task UpdateExerciseAsync(ExerciseItem exercise);
    Task DeleteExerciseAsync(ExerciseItem exercise);
}