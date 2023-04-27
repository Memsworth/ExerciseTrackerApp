using System.Text;
using ExerciseTracker.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.DataAccess;

public class ExerciseTrackerContext : DbContext
{
    public ExerciseTrackerContext(DbContextOptions<ExerciseTrackerContext> options) : base(options)
    { }
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<ExerciseItem> ExerciseItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Email).IsRequired().HasMaxLength(250);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(64);
            entity.HasMany(e => e.ExerciseItems)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
            entity.Property<DateTime>("CreateDate").HasDefaultValueSql("getdate()");
        });
        
        modelBuilder.Entity<ExerciseItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.StartTime).IsRequired();
            entity.Property(e => e.WorkoutName).IsRequired(false);
            entity.Property(e => e.EndTime).IsRequired(false);
            entity.Property(e => e.Duration).IsRequired(false);

        });
    }
}