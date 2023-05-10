using ExerciseTracker.Domain.Abstractions;
using ExerciseTracker.Domain.Abstractions.Repositories;
using ExerciseTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccess.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
    {
    }
}