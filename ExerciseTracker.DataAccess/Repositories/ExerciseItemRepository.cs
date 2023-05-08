using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.DataAccess.Repositories;

public class ExerciseItemRepository : GenericRepository<ExerciseItem>
{
    public ExerciseItemRepository(ExerciseTrackerDbContext exerciseTrackerDbContext) : base(exerciseTrackerDbContext)
    {
    }
}