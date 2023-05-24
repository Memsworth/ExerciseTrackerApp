using ExerciseTracker.Domain.DTO;
using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Domain.Abstractions.Services;

public interface IExerciseService
{
    Task<ExerciseItem> GetExerciseByIdAsync(int id);
    Task<List<ExerciseItem>> GetAllExerciseAsync();
    Task AddExerciseAsync(ExerciseItemPostDto exercise);
    Task UpdateExerciseAsync(ExerciseItem exerciseItem, ExerciseItemUpdateDto exerciseItemUpdateDto);
    Task DeleteExerciseAsync(ExerciseItem exercise);
}