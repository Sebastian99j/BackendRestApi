using BackendRestApi.Data;
using BackendRestApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

var options = new DbContextOptionsBuilder<AIContext>()
    .UseSqlServer(connectionString)
    .Options;

builder.Services.AddSingleton(AIContextSingleton.GetInstance(options));

builder.Services.AddScoped<AuthenticationRepository>();
builder.Services.AddScoped<TrainingSeriesRepository>();
builder.Services.AddScoped<TrainingTypeRepository>();
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

app.Urls.Add("http://+:8080");
//app.Urls.Add("https://+:8081");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
