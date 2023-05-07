using ExerciseTracker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExerciseTracker.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("getdate()");
            builder.Property(u => u.Email).IsRequired().HasMaxLength(250);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(64);

            builder
                .HasMany(e => e.ExerciseItems)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
        }
    }
}
