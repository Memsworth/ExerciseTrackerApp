using ExerciseTracker.Domain.Abstractions;
using ExerciseTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccess.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
    {
    }
    public async Task<User> GetById(int id)
    {
        try
        {
            return await _exerciseTrackerDbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}