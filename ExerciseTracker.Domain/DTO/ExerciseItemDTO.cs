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
    
    
}