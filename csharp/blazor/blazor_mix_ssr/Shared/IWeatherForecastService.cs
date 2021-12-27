namespace blazor_mix_ssr.Shared;

public interface IWeatherForecastService {
    Task<WeatherForecast[]?> GetForecastAsync();
}
