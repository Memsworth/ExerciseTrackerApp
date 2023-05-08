using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Domain.Abstractions;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetById(int id);
}