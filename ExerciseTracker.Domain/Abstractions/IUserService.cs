using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Domain.Abstractions;

public interface IUserService
{
    Task<User> InsertAsync(User entity);
}