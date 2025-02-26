using BackendRestApi.Data;
using BackendRestApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var options = new DbContextOptionsBuilder<AIContext>()
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .Options;

builder.Services.AddSingleton(AIContextSingleton.GetInstance(options));

builder.Services.AddScoped<AuthenticationRepository>();
builder.Services.AddScoped<TrainingSeriesRepository>();
builder.Services.AddScoped<TrainingTypeRepository>();
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
