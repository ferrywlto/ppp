Blazor WASM hosted version.

It serves the WASM via blazor server and perform server side rendering (SSR/Prerendering)

Project created via
```C#
dotnet new blazorwasm --hosted
```

Reference: 
- [Prerendering your Blazor WASM application with .NET 5 (part 1)](https://jonhilton.net/blazor-wasm-prerendering/)
- [Prerendering your Blazor WASM application with .NET 5 (part 2 - solving the missing HttpClient problem)](https://jonhilton.net/blazor-wasm-prerendering-missing-http-client/)

### Serve the html from server side instead of static `index.html`

1. Copy `index.html` from `Client/wwwroot` as `Server/Pages/_Host.cshtml`

2. Edit `Server/Pages/_Host.cshtml` as below:
   1. add the following at the top of the file:
   ```c#
    @page
    @namespace blazor_mix_ssr.Server.Pages
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
    ```
   2. add
   ```c#
    <component type="typeof(App)" render-mode="ServerPrerendered" />
    ```
   before
    ```c#
    <script src="_framework/blazor.webassembly.js"></script>
    ```
   3. remove unneeded code, the file should looks like:
   ```c#
   @page
   @using blazor_mix_ssr.Client
   @namespace blazor_mix_ssr.Server.Pages
   @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
   
   <!DOCTYPE html>
   <html lang="en">
   
   <head>
       <meta charset="utf-8" />
       <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
       <title>blazor_mix_ssr</title>
       <base href="/" />
       <link href="css/bootstrap/bootstrap.min.css" rel="stylesheet" />
       <link href="css/app.css" rel="stylesheet" />
       <link href="blazor_mix_ssr.Client.styles.css" rel="stylesheet" />
   </head>
   
   <body>
   <component type="typeof(App)" render-mode="ServerPrerendered" />
   <script src="_framework/blazor.webassembly.js"></script>
   </body>
   
   </html>
   ```
4. Redirect all route to prerendered. In `Server/Program.cs`, look for 

```c#
app.MapFallbackToFile("index.html");
```

and replace with

```c#
app.MapFallbackToPage("/_Host");
```

5. Since the app was prerendered from server, the client app should no longer load the app into `#app` tag. In `Client/Program.cs` remove this line:
```c#
builder.RootComponents.Add<App>("#app");
```

otherwise error show in console:
```c#
Microsoft.JSInterop.JSException: Could not find any element matching selector ‘#app’.
```

6. Solve client side dependency problem due to pre-rendering.
   1. Create `Shared/IWeatherForecaseService.cs`
   ```c#
   namespace blazor_mix_ssr.Shared;
   
   public interface IWeatherForecastService {
   Task<WeatherForecast[]> GetForecastAsync();
   }
   ```
   2. Implement client side service: `Client/Data/WeatherForecastService.cs`
   ```c#
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
   ```
   3. Change `Client/Pages/FetchData.razor`:
   add `@inject IWeatherForecastService _weatherForecastService` at the top of `Client/Pages/FetchData.razor`
   
   replace
   ```c#
   forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
   ```
   with
   ```c#
   forecasts = await _weatherForecastService.GetForecastAsync();
   ```

## Configure WeatherForecastService for Client project
### Add `WeatherForecastService` to DI in `Client/Program.cs`
```c#
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
await builder.Build().RunAsync();
```

7. Migrate `Server/Controller/WeatherForecastController.cs` logic to `Server/Data/WeatherForecastService.cs`:
`WeatherForecastController.cs`
```c#
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

```
`WeatherForecastService.cs`
```c#
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

```

## Configure WeatherForecastService for Server project
### Add `WeatherForecastService` to DI in `Server/Program.cs`
```c#
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
```

# Prevent `OnInitialized(Async)` called twice.
Pre-rendering on server will trigger `OnInitialized(Async)` once, then when browser received the whole HTML from server, `OnInitialized(Async)` will trigger again.

It cannot use `OnAfterRender` like the way calling JS.

The approach is to use cache (`IMemoryCache`) to return the same result so the data on page won't flicker/change during two loads.
[Stateful reconnection after prerendering](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-6.0#stateful-reconnection-after-prerendering)


# Execute JS from razor component.
1. JS need to export or add to global function like:
```js
//in Server/Pages/_Host.html
<script>
    window.func1 = () => alert("Hello!");
</script>
```
2. Inject `IJSRuntime` at the top of razor component:
```c#
// in Client/Pages/FetchData.razor
@inject IJSRuntime _js
```

3. Only executable from `OnAfterRender` life-cycle hook:
```c#
// in Client/Pages/FetchData.razor
 protected override async void OnAfterRender(bool firstRender) {
     await _js.InvokeVoidAsync("func1");
 }
```
if not limiting the function called only at the firstRender (i.e. pre-rending stage on server). The code will execute again when finished loading on browser.
