using ExerciseTracker.Domain.Abstractions.Services;
using ExerciseTracker.Domain.Abstractions.UnitOfWork;
using ExerciseTracker.Domain.Models;
using ExerciseTracker.WebApi.DTO;

namespace ExerciseTracker.Service;

public class ExerciseService : IExerciseService
{
    protected readonly IUnitOfWork _unitOfWork;

    public ExerciseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ExerciseItem> GetExerciseByIdAsync(int id)
    {
        return await _unitOfWork.ExerciseItemRepository.GetAsync(id);
    }

    public async Task<List<ExerciseItem>> GetAllExerciseAsync()
    {
        var items = await _unitOfWork.ExerciseItemRepository.GetAsync();
        return items.ToList();
    }

    public async Task AddExerciseAsync(ExerciseItemPostDTO exercise)
    {
        await _unitOfWork.ExerciseItemRepository.AddAsync(exercise.ToDbo());
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateExerciseAsync(ExerciseItem exerciseItem, ExerciseItemUpdateDto exerciseItemUpdateDto)
    {
        await _unitOfWork.ExerciseItemRepository.UpdateAsync(exerciseItem.UpdateItem(exerciseItemUpdateDto));
        await _unitOfWork.CommitAsync();
    }
    public async Task DeleteExerciseAsync(ExerciseItem exercise)
    {
        await _unitOfWork.ExerciseItemRepository.DeleteAsync(exercise);
        await _unitOfWork.CommitAsync();
    }
}