// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }


// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// app.MapGet("/", () => Results.Ok(new
// {
//     message = "Hello World from Azure App Service!",
//     timestampUtc = DateTime.UtcNow
// }));

// app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

// // Demonstrate config/secret injection (from App Settings / Key Vault reference)
// app.MapGet("/secret-demo", (IConfiguration config) =>
// {
//     var secretValue = config["DEMO_SECRET"] ?? "(not set)";
//     return Results.Ok(new { demoSecret = secretValue });
// });

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.Run();

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// -----------------------------
// NORMAL ENDPOINTS
// -----------------------------
app.MapGet("/", () => Results.Ok(new
{
    message = "Hello World from Azure App Service!",
    timestampUtc = DateTime.UtcNow
}));

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

// -----------------------------
// WEATHER FORECAST ENDPOINT
// -----------------------------
app.MapGet("/weatherforecast", () =>
{
    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

// -----------------------------
// SECRET EXPOSURE (DEMO)
// -----------------------------
app.MapGet("/secret-demo", (IConfiguration config) =>
{
    // ❌ Hardcoded secret (for demo)
    var apiKey = "sk_test_1234567890";

    return Results.Ok(new
    {
        configSecret = config["DEMO_SECRET"],
        hardcodedSecret = apiKey
    });
});

// -----------------------------
// COMMAND INJECTION (DEMO)
// -----------------------------
app.MapGet("/run", ([FromQuery] string cmd) =>
{
    // ❌ Command Injection vulnerability
    var process = Process.Start("cmd.exe", "/c " + cmd);
    return Results.Ok("Command executed");
});

// -----------------------------
// INSECURE DESERIALIZATION (DEMO)
// -----------------------------
app.MapPost("/deserialize", ([FromBody] string payload) =>
{
    // ❌ Insecure deserialization
    var obj = System.Text.Json.JsonSerializer.Deserialize<object>(payload);
    return Results.Ok(obj);
});

// -----------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

// Make Program class accessible for integration tests
public partial class Program { }

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
