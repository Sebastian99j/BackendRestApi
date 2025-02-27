using BackendRestApi.Data;
using BackendRestApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var certPath = Environment.GetEnvironmentVariable("CERT_PATH") ?? "/https/cert.pfx";
var certPassword = Environment.GetEnvironmentVariable("CERT_PASSWORD") ?? "YourStrongPassword";

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080); // HTTP
    serverOptions.ListenAnyIP(8081, listenOptions =>
    {
        listenOptions.UseHttps(certPath, certPassword);
    });
});

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

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();