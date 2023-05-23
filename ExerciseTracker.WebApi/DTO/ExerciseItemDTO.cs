using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.WebApi.DTO;

public class ExerciseItemPostDTO
{
    public string? WorkoutName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}

public class ExerciseItemDisplayDTO
{
    public int Id { get; set; }
    public string? WorkoutName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public TimeSpan? Duration { get; set; }
}

public class ExerciseItemUpdateDto
{
    public string? WorkoutName { get; set; }
    public DateTime? EndTime { get; set; }
}

public static class DTOExtention
{
    public static ExerciseItemDisplayDTO ToDto(this ExerciseItem exerciseItem) => new ExerciseItemDisplayDTO()
    {
        Id = exerciseItem.Id,
        WorkoutName = exerciseItem.WorkoutName,
        StartTime = exerciseItem.StartTime,
        EndTime = exerciseItem.EndTime,
        Duration = exerciseItem.Duration
    };
    
    public static ExerciseItem ToDbo(this ExerciseItemPostDTO exerciseItemDto) => new ExerciseItem()
    {
        WorkoutName = exerciseItemDto.WorkoutName,
        StartTime = exerciseItemDto.StartTime,
        EndTime = exerciseItemDto.EndTime,
        Duration = exerciseItemDto.StartTime - exerciseItemDto.EndTime
    };
    
}