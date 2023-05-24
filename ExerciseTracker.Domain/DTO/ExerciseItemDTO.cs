namespace ExerciseTracker.Domain.DTO;

public class ExerciseItemPostDto
{
    public string? WorkoutName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}

public class ExerciseItemDisplayDto
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