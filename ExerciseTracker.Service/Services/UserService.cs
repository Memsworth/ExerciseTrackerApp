using ExerciseTracker.Domain.Abstractions;
using ExerciseTracker.Domain.Abstractions.Repositories;
using ExerciseTracker.Domain.Abstractions.Services;
using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task InsertAsync(User entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} entity is null");
        }
        
        await _userRepository.Add(entity);
    }
}