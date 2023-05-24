using ExerciseTracker.Domain.DTO;
using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Service;

public static class DtoExtension
{
    public static ExerciseItemDisplayDto ToDto(this ExerciseItem exerciseItem) => new ExerciseItemDisplayDto()
    {
        Id = exerciseItem.Id,
        WorkoutName = exerciseItem.WorkoutName,
        StartTime = exerciseItem.StartTime,
        EndTime = exerciseItem.EndTime,
        Duration = exerciseItem.Duration
    };

    public static ExerciseItem UpdateItem(this ExerciseItem exerciseItem, ExerciseItemUpdateDto exerciseItemUpdateDto)
    {
        exerciseItem.WorkoutName = exerciseItemUpdateDto.WorkoutName;
        exerciseItem.EndTime = exerciseItemUpdateDto.EndTime;
        exerciseItem.Duration = exerciseItem.EndTime - exerciseItem.StartTime;
        return exerciseItem;
    }
    public static ExerciseItem ToDbo(this ExerciseItemPostDto exerciseItemDto) => new ExerciseItem()
    {
        WorkoutName = exerciseItemDto.WorkoutName,
        StartTime = exerciseItemDto.StartTime,
        EndTime = exerciseItemDto.EndTime,
        Duration = exerciseItemDto.StartTime - exerciseItemDto.EndTime
    };
}