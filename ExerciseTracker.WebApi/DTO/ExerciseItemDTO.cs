using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.WebApi.DTO;

public class ExerciseItemDTO
{
    public string? WorkoutName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
}


public static class DTOExtention
{
    public static ExerciseItemDTO ToDto(this ExerciseItem exerciseItem) => new ExerciseItemDTO()
    {
        WorkoutName = exerciseItem.WorkoutName,
        StartTime = exerciseItem.StartTime,
        EndTime = exerciseItem.EndTime,
    };
    
    public static ExerciseItem ToDbo(this ExerciseItemDTO exerciseItemDto) => new ExerciseItem()
    {
        WorkoutName = exerciseItemDto.WorkoutName,
        StartTime = exerciseItemDto.StartTime,
        EndTime = exerciseItemDto.EndTime,
        Duration = exerciseItemDto.StartTime - exerciseItemDto.EndTime
    };
    
}