using ExerciseTracker.DataAccess;
using ExerciseTracker.DataAccess.UnitOfWork;
using ExerciseTracker.Domain.Abstractions.Services;
using ExerciseTracker.Domain.Abstractions.UnitOfWork;
using ExerciseTracker.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var dbpath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ExerciseTracker.db");
builder.Services.AddDbContext<ExerciseTrackerDbContext>(options => options.UseSqlite($"Data Source = {dbpath}"));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IExerciseService, ExerciseService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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