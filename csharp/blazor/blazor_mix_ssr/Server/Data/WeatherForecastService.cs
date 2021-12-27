using blazor_mix_ssr.Shared;

namespace blazor_mix_ssr.Server.Data;

public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<WeatherForecast[]?> GetForecastAsync()
    {
        var rng = new Random();
        await Task.Delay(10);
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                         {
                             Date = DateTime.Now.AddDays(index),
                             TemperatureC = rng.Next(-20, 55),
                             Summary = Summaries[rng.Next(Summaries.Length)]
                         })
                         .ToArray();
    }
}
