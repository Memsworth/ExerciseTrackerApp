using ExerciseTracker.Domain.Abstractions.Repositories;
using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.DataAccess.Repositories;

public class ExerciseRepository : GenericRepository<ExerciseItem>, IExerciseItemRepository
{
    public ExerciseRepository(ExerciseTrackerDbContext dbContext) : base(dbContext)
    { }
}