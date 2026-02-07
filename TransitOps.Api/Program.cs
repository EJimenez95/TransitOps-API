using TransitOps.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Service Registration
// --------------------

// Add MVC controllers to the dependency injection container
builder.Services.AddControllers();

// Enables minimal API metadata for tools like Swagger
builder.Services.AddEndpointsApiExplorer();

// Registers Swagger for API documentation and testing
builder.Services.AddSwaggerGen();

// Register Entity Framework Core DbContext
// Uses SQL Server and reads the connection string from appsettings.json
builder.Services.AddDbContext<TransitOpsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// --------------------
// HTTP Request Pipeline
// --------------------

if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI only in development
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enables authorization middleware (for future auth features)
app.UseAuthorization();

// Map controller routes (attribute-based routing)
app.MapControllers();

// Start the application
app.Run();
