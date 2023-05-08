using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Domain.Abstractions;

public interface IUserRepository
{
    void InsertUser(User user);
    void DeleteSUser(int id);
}