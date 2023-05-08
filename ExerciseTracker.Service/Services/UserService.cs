using ExerciseTracker.DataAccess.Repositories;
using ExerciseTracker.Domain.Abstractions;
using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Service.Services;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task InsertAsync(User entity)
    {
         await _userRepository.InsertAsync(entity);
    }
}