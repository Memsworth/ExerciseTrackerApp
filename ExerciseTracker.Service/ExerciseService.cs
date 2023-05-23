using ExerciseTracker.Domain.Abstractions.Services;
using ExerciseTracker.Domain.Abstractions.UnitOfWork;
using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Service;

public class ExerciseService : IExerciseService
{
    protected readonly IUnitOfWork _unitOfWork;

    public ExerciseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ExerciseItem> GetExerciseByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ExerciseItem>> GetAllExerciseAsync()
    {
        var items = await _unitOfWork.ExerciseItemRepository.GetAsync();
        return items.ToList();
    }

    public async Task AddExerciseAsync(ExerciseItem exercise)
    {
        await _unitOfWork.ExerciseItemRepository.AddAsync(exercise);
        await _unitOfWork.CommitAsync();
    }
}