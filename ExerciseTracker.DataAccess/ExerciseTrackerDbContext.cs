using ExerciseTracker.DataAccess.Configurations;
using ExerciseTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccess
{
    public class ExerciseTrackerDbContext : DbContext
    {
        public ExerciseTrackerDbContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ExerciseItem> ExerciseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciseItemConfiguration());
        }
    }
}
