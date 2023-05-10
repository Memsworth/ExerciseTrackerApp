using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Domain.Abstractions.Services;

public interface IUserService
{
    Task InsertAsync(User entity);
}