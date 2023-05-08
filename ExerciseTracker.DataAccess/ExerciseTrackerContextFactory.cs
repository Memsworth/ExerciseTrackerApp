using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExerciseTracker.DataAccess;

public class ExerciseTrackerContextFactory : IDesignTimeDbContextFactory<ExerciseTrackerDbContext>
{
    public ExerciseTrackerDbContext CreateDbContext(string[] args)
    {
        var folder = Environment.SpecialFolder.MyDocuments;
        var path = Environment.GetFolderPath(folder);
        var dbPath = Path.Join(path, "ExerciseTracker.db");
        var optionBuilder = new DbContextOptionsBuilder<ExerciseTrackerDbContext>();
        optionBuilder.UseSqlite($"Data Source = {dbPath}");

        return new ExerciseTrackerDbContext(optionBuilder.Options);
    }
}