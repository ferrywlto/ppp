using System.Net.Http.Json;
using blazor_mix_ssr.Shared;

namespace blazor_mix_ssr.Client.Data;

public class WeatherForecastService : IWeatherForecastService {
    private readonly HttpClient _httpClient;
    public WeatherForecastService(HttpClient httpClient) { _httpClient = httpClient; }
    public async Task<WeatherForecast[]?> GetForecastAsync() {
        return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
    }
}
