var builder = WebApplication.CreateBuilder(args);

// 1. Enable CORS so your Angular app can call this API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAngular");

// 2. Create the simple GET endpoint
app.MapGet("/api/hello", (string name) =>
{
    if (string.IsNullOrWhiteSpace(name))
    {
        return Results.Ok(new { message = "Hello World!" });
    }
    return Results.Ok(new { message = $"Hello World, {name}!" });
});

app.Run();
