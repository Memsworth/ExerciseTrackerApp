using ExerciseTracker.DataAccess;
using ExerciseTracker.DataAccess.Repositories;
using ExerciseTracker.Domain.Abstractions;
using ExerciseTracker.Domain.Abstractions.Repositories;
using ExerciseTracker.Domain.Abstractions.Services;
using ExerciseTracker.Domain.Models;
using ExerciseTracker.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var dbpath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ExerciseTracker.db");
builder.Services.AddDbContext<ExerciseTrackerDbContext>(options => options.UseSqlite($"Data Source = {dbpath}"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();