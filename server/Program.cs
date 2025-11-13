var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
#if DEBUG
builder.Services.AddOpenApi();
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin();
    });
});
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.

#if DEBUG
app.UseCors();
app.MapOpenApi();
#endif

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");

var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

app.MapGet("/weather", () => {
    var forecast = Enumerable.Range(1, Random.Shared.Next(10)).Select(index =>
        new WeatherForecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            )).ToArray();


    return forecast;
}).WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary) {
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
