using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using blazor_mix_ssr.Client.Data;
using blazor_mix_ssr.Shared;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>(
    config => {
        var httpClient = config.GetService<HttpClient>();

        return new WeatherForecastService(httpClient);
    });

builder.Services.AddScoped<InjectAppState>();
builder.Services.AddMudServices();
await builder.Build().RunAsync();
