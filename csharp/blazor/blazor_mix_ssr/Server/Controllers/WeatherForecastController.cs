using Microsoft.AspNetCore.Mvc;
using blazor_mix_ssr.Shared;

namespace blazor_mix_ssr.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService) {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>?> Get() {
        return await _weatherForecastService.GetForecastAsync();
    }
}
