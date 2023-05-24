using ExerciseTracker.Domain.Models;
using ExerciseTracker.WebApi.DTO;

namespace ExerciseTracker.Domain.Abstractions.Services;

public interface IExerciseService
{
    Task<ExerciseItem> GetExerciseByIdAsync(int id);
    Task<List<ExerciseItem>> GetAllExerciseAsync();
    Task AddExerciseAsync(ExerciseItemPostDTO exercise);
    Task UpdateExerciseAsync(ExerciseItem exerciseItem, ExerciseItemUpdateDto exerciseItemUpdateDto);
    Task DeleteExerciseAsync(ExerciseItem exercise);
}