using ExerciseTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExerciseTracker.DataAccess.Configurations;

public class ExerciseItemConfiguration : IEntityTypeConfiguration<ExerciseItem>
{
    public void Configure(EntityTypeBuilder<ExerciseItem> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.StartTime).IsRequired();
        builder.Property(e => e.WorkoutName).IsRequired(false);
        builder.Property(e => e.EndTime).IsRequired(false);
        builder.Property(e => e.Duration).IsRequired(false);
    }
}