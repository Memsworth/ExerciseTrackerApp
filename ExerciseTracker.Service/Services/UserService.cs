using ExerciseTracker.Domain.Abstractions;
using ExerciseTracker.Domain.Abstractions.Repositories;
using ExerciseTracker.Domain.Abstractions.Services;
using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> InsertAsync(User entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} entity is null");
        }

        await _userRepository.Add(entity);
        var resultOfOperation = await _unitOfWork.Save();

        return resultOfOperation == 0;
    }
}