﻿using ExerciseTracker.Domain.Models;

namespace ExerciseTracker.Domain.Abstractions;

public interface IUserRepository<T>
{
    Task<T> GetById(int id);
}