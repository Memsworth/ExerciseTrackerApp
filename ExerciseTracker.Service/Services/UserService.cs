using ExerciseTracker.Domain.Abstractions;
using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> InsertAsync(User entity)
    {
        return await _userRepository.InsertAsync(entity);
    }
}