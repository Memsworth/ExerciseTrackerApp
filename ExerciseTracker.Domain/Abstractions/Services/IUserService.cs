using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Domain.Abstractions.Services;

public interface IUserService
{
    Task<bool> InsertAsync(User entity);
}