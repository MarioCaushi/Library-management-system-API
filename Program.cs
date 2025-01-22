using Library_management_system_API.Data;
using Library_management_system_API.Models;
using Library_management_system_API.Services;
using Library_management_system_API.Services.Manager;
using Library_management_system_API.Services.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;
using static Library_management_system_API.Errors.ExceptionsMiddlewareExtensions;

var builder = WebApplication.CreateBuilder(args);

// Manually load .env file
LoadEnvVariables();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddCors();

// Retrieve the environment variable and check
var configuration = builder.Configuration;
var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD") ?? throw new InvalidOperationException("The 'MYSQL_PASSWORD' environment variable is not set.");

// Retrieve and build the connection string
var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("The 'DefaultConnection' connection string is missing in the configuration.");
connectionString = connectionString.Replace("${MYSQL_PASSWORD}", password);

// Configure the DbContext with MySQL
builder.Services.AddDbContext<LibraryDB>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(9, 1, 0)))
);

// Register the Swagger generator
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });
});

// Register the services

builder.Services.AddScoped<IExample, Example>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IClientService, ClientsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // The default is /swagger
    });
}

app.UseCors(options =>
    options.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());

app.UseHttpsRedirection();

// Exception Handling
app.ConfigureBuildInExceptionHandlers();

app.MapControllers();
app.Run();

//Function to load the content of .env file manually 
void LoadEnvVariables()
{
    var envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
    if (!File.Exists(envPath))
        return;

    foreach (var line in File.ReadAllLines(envPath))
    {
        var parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2) continue;
        Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
    }
}