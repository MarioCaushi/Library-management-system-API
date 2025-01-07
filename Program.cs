using Library_management_system_API.Data;
using Microsoft.EntityFrameworkCore;
using static Library_management_system_API.Errors.ExceptionsMiddlewareExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddCors();

// Retrieve the environment variable and connection string
var configuration = builder.Configuration;
var password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");

// Check if the environment variable is set
if (string.IsNullOrEmpty(password))
{
    throw new InvalidOperationException("The 'MYSQL_PASSWORD' environment variable is not set. Please set it to connect to the database.");
}

// Retrieve and replace the placeholder in the connection string
var connectionString = configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("The 'DefaultConnection' connection string is missing in the configuration.");
}

// Replace the placeholder with the actual password
connectionString = connectionString.Replace("${MYSQL_PASSWORD}", password);

// Log the connection string usage (without exposing sensitive data)
builder.Logging.AddConsole();
builder.Logging.AddDebug();
var logger = LoggerFactory.Create(logging => logging.AddConsole()).CreateLogger<Program>();
logger.LogInformation("Connection string configured successfully (password hidden).");

// Configure the DbContext
builder.Services.AddDbContext<LibraryDB>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(9, 1, 0)))
);

// Configure DbContext with the updated connection string
builder.Services.AddDbContext<LibraryDB>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(9, 1, 0)) 
    ));

// Register the Swagger generator
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });
});

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