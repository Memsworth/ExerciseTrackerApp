namespace ExerciseTracker.DataAccess.Models;

public class ExerciseItem
{
    public int Id { get; set; }
    public string? WorkoutName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public TimeSpan? Duration { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
}