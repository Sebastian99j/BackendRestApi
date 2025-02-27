using BackendRestApi.Data;
using BackendRestApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Access-Control-Allow-Origin");
    });
});

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080);
});


//var certPath = Environment.GetEnvironmentVariable("CERT_PATH") ?? "/https/cert.pfx";
//var certPassword = Environment.GetEnvironmentVariable("CERT_PASSWORD") ?? "YourStrongPassword";

//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ListenAnyIP(8080); // HTTP //8133
//    serverOptions.ListenAnyIP(8081, listenOptions => //8134
//    {
//        listenOptions.UseHttps(certPath, certPassword);
//    });
//});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextFactory<AIContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<AuthenticationRepository>();
builder.Services.AddScoped<TrainingSeriesRepository>();
builder.Services.AddScoped<TrainingTypeRepository>();
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AIContext>();
        if (dbContext.Database.CanConnect())
        {
            dbContext.Database.Migrate();
            Console.WriteLine("Database migration completed.");
        }
    }
}

app.UseCors("AllowAll");

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();